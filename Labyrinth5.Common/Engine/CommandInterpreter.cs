﻿namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.Engine.Commands;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;
    using System;

    /// <summary>
    /// Handles all input. Dispatches commands
    /// </summary>
    internal class CommandInterpreter : ICommandInterpreter
    {
        private const int MinimumMazeSize = 10;
        private const int MaximumMazeSize = 60;
        private const int DefaultMazeRows = 15;
        private const int DefaultMazeColumns = 20;

        private const string MoveCommand = "move";
        private const string MoveCommandShortcut = "m";
        private const string MoveUpSubCommand = "up";
        private const string MoveUpSubCommandShortcut = "w";
        private const string MoveRightSubCommand = "right";
        private const string MoveRightSubCommandShortcut = "d";
        private const string MoveDownSubCommand = "down";
        private const string MoveDownSubCommandShortcut = "s";
        private const string MoveLeftSubCommand = "left";
        private const string MoveLeftSubCommandShortcut = "a";
        private const string InitializeGameCommand = "init";
        private const string DisplayInstructionsCommand = "info";
        private const string EndGameCommand = "exit";
        private const string SetGenerationStrategyCommand = "set";
        private const string BacktrackerStrategySubCommand = "backtracker";
        private const string PrimStrategySubCommand = "prim";
        private const string InvalidCommand = "Invalid Command";
        private const string IllegalMove = "Illegal Move";
        private const string InvalidArguments = "Invalid Arguments";
        private const string SuccessMessage = "Success! Score: {0}. Press <ENTER> to play again.";
        private const string StrategySwitchedMessage = "Generation algorithm set to : {0}";


        private readonly string blankLine = new string(' ', Console.WindowWidth);
        private readonly char[] separators = new char[] { ' ' };
        
        private readonly IRenderer renderer = new ConsoleRenderer();
        private readonly Player player = new Player();
        private readonly Maze maze = new Maze(new BacktrackerMazeGenerator());

        private readonly ICommand playerMoveCommand;
        private readonly ICommand displayInstructionsCommand;
       
        private int cursorPositionLeft;
        private int cursorPositionTop;
        private int steps;
        //TODO: Integrate scoreboard

        public CommandInterpreter()
        {
            this.playerMoveCommand = new PlayerMoveCommand(player);
            this.displayInstructionsCommand = new DisplayInstructionsCommand(renderer);
        }

        /// <summary>
        /// Dispatches commands to command handlers
        /// </summary>
        /// <param name="command">User input string</param>
        public void ParseAndDispatch(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                var commandWords = command.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if ((commandWords[0] == MoveCommand || commandWords[0] == MoveCommandShortcut) 
                    && commandWords.Length > 1)
                {
                    this.HandleMoveCommand(commandWords[1]);
                }
                else if (commandWords[0] == InitializeGameCommand)
                {
                    this.HandleInitCommand(commandWords);
                }
                else if (commandWords[0] == DisplayInstructionsCommand)
                {
                    this.HandleInfoCommand();
                }
                else if (commandWords[0] == SetGenerationStrategyCommand && commandWords.Length > 0)
                {
                    this.HandleSetCommand(commandWords[1]);
                }
                else if (commandWords[0] == EndGameCommand)
                {
                    this.HandleExitCommand();
                }
                else
                {
                    this.renderer.RenderText(InvalidCommand, this.cursorPositionLeft, this.cursorPositionTop - 1);
                }
            }

            this.renderer.RenderText(blankLine, this.cursorPositionLeft, this.cursorPositionTop);
            Console.SetCursorPosition(this.cursorPositionLeft, this.cursorPositionTop);
        }

        /// <summary>
        /// Sets up new game on user input
        /// </summary>
        /// <param name="commandWords">String array, default maze on 1 element, custom on 3 elements</param>
        private void HandleInitCommand(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                int mazeRows;
                int mazeColumns;

                if (int.TryParse(commandWords[1], out mazeRows) && int.TryParse(commandWords[2], out mazeColumns))
                {
                    if (MinimumMazeSize <= mazeRows &&  mazeRows <= MaximumMazeSize
                        && MinimumMazeSize <= mazeColumns && mazeColumns <= MaximumMazeSize)
                    {
                        this.SetUpGame(mazeRows, mazeColumns);
                    }
                }
                else
                {
                    renderer.RenderText(InvalidArguments, this.cursorPositionLeft, cursorPositionTop - 1);
                }
            }
            else
            {
                this.SetUpGame(DefaultMazeRows, DefaultMazeColumns);
            }
        }

        
        /// <summary>
        /// Displays info. Renders the playing field again when closed.
        /// </summary>
        private void HandleInfoCommand()
        {
            this.displayInstructionsCommand.Execute();
            Console.ReadKey();
            this.RenderGameComponents();
        }

        /// <summary>
        /// Changes player position.
        /// Prints current position.
        /// Displays Game Over message on reaching the exit
        /// </summary>
        /// <param name="command"></param>
        private void HandleMoveCommand(string command)
        {
            if (command == MoveUpSubCommand || command == MoveUpSubCommandShortcut)
            {
                this.player.Direction = Directions.Up;
            }
            else if (command == MoveRightSubCommand || command == MoveRightSubCommandShortcut)
            {
                this.player.Direction = Directions.Right;
            }
            else if (command == MoveDownSubCommand || command == MoveDownSubCommandShortcut)
            {
                this.player.Direction = Directions.Down;
            }
            else if (command == MoveLeftSubCommand || command == MoveLeftSubCommandShortcut)
            {
                this.player.Direction = Directions.Left;
            }

            if (this.IsPositionAvailable())
            {
                this.steps++;
                this.renderer.Clear(player);
                this.playerMoveCommand.Execute();
                this.renderer.Render(player);
                renderer.RenderText(blankLine, this.cursorPositionLeft, this.cursorPositionTop - 1);
            }
            else
            {
                renderer.RenderText(IllegalMove, this.cursorPositionLeft, this.cursorPositionTop - 1);
            }

            if (this.HasReachedTheExit())
            {
                this.HandleGameEnded();
            }
        }

        private bool IsPositionAvailable()
        {
            var position = this.player.TopLeftPosition + this.player.Direction;
            return !this.maze[position.Row, position.Col].IsWall;
        }

        private bool HasReachedTheExit()
        {
            var position = this.player.TopLeftPosition;
            return this.maze[position.Row, position.Col].IsExit;
        }

        private void HandleExitCommand()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Generates new maze. Clars console and prints maze by given rows and cols.
        /// </summary>
        /// <param name="mazeRows"></param>
        /// <param name="mazeColumns"></param>
        private void SetUpGame(int mazeRows, int mazeColumns)
        {
            this.maze.Generate(mazeRows, mazeColumns);

            this.player.TopLeftPosition = new MatrixCoordinates(
                this.maze.TopLeftPosition.Row + 1,
                this.maze.TopLeftPosition.Col + 1);

            this.cursorPositionLeft = 0;
            this.cursorPositionTop = this.maze.Rows + 2;
            this.steps = 0;
            this.RenderGameComponents();
        }

        private void HandleGameEnded()
        {
            var totalScore = this.maze.Rows * this.maze.Columns - this.steps;

            renderer.RenderText(
                string.Format(SuccessMessage, totalScore), 
                this.cursorPositionLeft, 
                this.cursorPositionTop - 1);

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                this.SetUpGame(DefaultMazeRows, DefaultMazeColumns);
            }
            else
            {
                this.HandleExitCommand();
            }
        }

        private void RenderGameComponents()
        {
            this.renderer.ClearAll();
            this.renderer.Render(maze);
            this.renderer.Render(player);
        }

        private void HandleSetCommand(string strategyName)
        {
            strategyName = strategyName.ToLower();

            if (strategyName == BacktrackerStrategySubCommand)
            {
                this.maze.GenerationStrategy = new BacktrackerMazeGenerator();
            }
            else if (strategyName == PrimStrategySubCommand)
            {
                this.maze.GenerationStrategy = new PrimMazeGenerator();
            }

            var message = string.Format(StrategySwitchedMessage, strategyName);
            renderer.RenderText(blankLine, this.cursorPositionLeft, this.cursorPositionTop - 1);
            renderer.RenderText(message, this.cursorPositionLeft, this.cursorPositionTop - 1);
        }
    }
}