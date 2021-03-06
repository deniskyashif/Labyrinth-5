﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandInterpreter.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
// Internal class that handles all input. Dispatches commands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Engine
{
    using System;
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.Engine.Commands;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;

    /// <summary>
    /// Internal class that handles all input. Dispatches commands.
    /// </summary>
    internal class CommandInterpreter : ICommandInterpreter
    {
        /// <summary>
        /// Minimum size of a generated maze.
        /// </summary>
        private const int MinimumMazeSize = 10;

        /// <summary>
        /// Maximum size of a generated maze.
        /// </summary>
        private const int MaximumMazeSize = 60;

        /// <summary>
        /// Default number of rows.
        /// </summary>
        private const int DefaultMazeRows = 15;

        /// <summary>
        /// Default number of cols.
        /// </summary>
        private const int DefaultMazeColumns = 20;

        /// <summary>
        /// Move command string.
        /// </summary>        
        private const string MoveCommand = "move";

        /// <summary>
        /// Move command string short.
        /// </summary>    
        private const string MoveCommandShortcut = "m";

        /// <summary>
        /// Up command string.
        /// </summary>
        private const string MoveUpSubCommand = "up";

        /// <summary>
        /// Up command string short.
        /// </summary>
        private const string MoveUpSubCommandShortcut = "w";

        /// <summary>
        /// Right command string.
        /// </summary>
        private const string MoveRightSubCommand = "right";

        /// <summary>
        /// Right command string short.
        /// </summary>
        private const string MoveRightSubCommandShortcut = "d";

        /// <summary>
        /// Down command string.
        /// </summary>
        private const string MoveDownSubCommand = "down";

        /// <summary>
        /// Down command string short.
        /// </summary>
        private const string MoveDownSubCommandShortcut = "s";

        /// <summary>
        /// Left command string.
        /// </summary>
        private const string MoveLeftSubCommand = "left";

        /// <summary>
        /// Left command string short.
        /// </summary>
        private const string MoveLeftSubCommandShortcut = "a";

        /// <summary>
        /// Initialize game command string.
        /// </summary>
        private const string InitializeGameCommand = "init";

        /// <summary>
        /// Display info command string.
        /// </summary>
        private const string DisplayInstructionsCommand = "info";

        /// <summary>
        /// Initialize game command string.
        /// </summary>
        private const string DisplayScoreboardCommand = "score";

        /// <summary>
        /// End game command string.
        /// </summary>
        private const string EndGameCommand = "exit";

        /// <summary>
        /// Set game maze generator algorithm command string.
        /// </summary>
        private const string SetGenerationStrategyCommand = "set";

        /// <summary>
        /// Backtracker algorithm command string.
        /// </summary>
        private const string BacktrackerStrategySubCommand = "backtracker";

        /// <summary>
        /// Prim algorithm command string.
        /// </summary>
        private const string PrimStrategySubCommand = "prim";

        /// <summary>
        /// Invalid command string.
        /// </summary>
        private const string InvalidCommand = "Invalid Command";

        /// <summary>
        /// Illegal move command string.
        /// </summary>
        private const string IllegalMove = "Illegal Move";

        /// <summary>
        /// Invalid Arguments command string.
        /// </summary>
        private const string InvalidArguments = "Invalid Arguments";

        /// <summary>
        /// Success message command string.
        /// </summary>
        private const string SuccessMessage = "Success! Score: {0}. Enter your name: ";

        /// <summary>
        /// Algorithm choice message command.
        /// </summary>
        private const string StrategySwitchedMessage = "Generation algorithm set to : {0}";

        /// <summary>
        /// Path to the file, which keeps the high scores.
        /// </summary>
        private const string ScoreboardFilePath = "../../../Labyrinth5.Common/Save/SavedScores.txt";

        /// <summary>
        /// Blank line.
        /// </summary>
        private readonly string blankLine = new string(' ', Console.WindowWidth);

        /// <summary>
        /// Separators for game elements.
        /// </summary>
        private readonly char[] separators = new char[] { ' ', '/', ',', '-', ';' };

        /// <summary>
        /// Game  console renderer.
        /// </summary>
        private readonly IRenderer renderer = new ConsoleRenderer();

        /// <summary>
        /// Game player.
        /// </summary>
        private readonly Player player = new Player();

        /// <summary>
        /// Game Maze.
        /// </summary>
        private readonly Maze maze = new Maze(new BacktrackerMazeGenerator());

        /// <summary>
        /// Game Scoreboard.
        /// </summary>
        private readonly ScoreboardManager scoreboard = new ScoreboardManager(ScoreboardFilePath, separators: new[] { '/' });

        /// <summary>
        /// Player move command instance.
        /// </summary>
        private readonly ICommand playerMoveCommand;

        /// <summary>
        /// Display Info command instance.
        /// </summary>
        private readonly ICommand displayInstructionsCommand;

        /// <summary>
        /// Set to generation algorithm to Backtracker command instance.
        /// </summary>
        private readonly ICommand setToBacktrackerCommand;

        /// <summary>
        /// Set generation algorithm to Prim command instance.
        /// </summary>
        private readonly ICommand setToPrimCommand;

        /// <summary>
        /// Display Scoreboard command Instance.
        /// </summary>
        private readonly ICommand displayScoreboardCommand;

        /// <summary>
        /// Cursor  left coordinate..
        /// </summary>
        private int cursorPositionLeft;

        /// <summary>
        /// Cursor  top coordinate..
        /// </summary>
        private int cursorPositionTop;

        /// <summary>
        /// Steps taken during a game.
        /// </summary>
        private int steps;

        /// <summary>
        /// Initializes a new instance of the<see cref="CommandInterpreter"/> class.
        /// Initializes  the local instance of PlayerMoveCommand.
        /// Initializes the local instance of DisplayInstructionsCommand.
        /// </summary>
        public CommandInterpreter()
        {
            this.playerMoveCommand = new PlayerMoveCommand(this.player);
            this.displayInstructionsCommand = new DisplayInstructionsCommand(this.renderer);
            this.displayScoreboardCommand = new DisplayScoreboardCommand(this.renderer, this.scoreboard);
            this.setToBacktrackerCommand = new SetBacktrackerCommand(this.maze);
            this.setToPrimCommand = new SetPrimCommand(this.maze);
            
            this.ResetGameVariables(DefaultMazeRows, DefaultMazeColumns);
        }

        /// <summary>
        /// Dispatches commands to command handlers.
        /// </summary>
        /// <param name="command">User input string.</param>
        public void ParseAndDispatch(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                var commandWords = command.ToLower().Split(this.separators, StringSplitOptions.RemoveEmptyEntries);

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
                else if (commandWords[0] == DisplayScoreboardCommand)
                {
                    this.HandleScoreCommand();
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

            this.renderer.RenderText(this.blankLine, this.cursorPositionLeft, this.cursorPositionTop);
            Console.SetCursorPosition(this.cursorPositionLeft, this.cursorPositionTop);
        }

        /// <summary>
        /// Sets up a new game on user input.
        /// </summary>
        /// <param name="commandWords">String array, default maze on 1 element, custom on 3 elements.</param>
        private void HandleInitCommand(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                int mazeRows;
                int mazeColumns;

                if (int.TryParse(commandWords[1], out mazeRows) && int.TryParse(commandWords[2], out mazeColumns))
                {
                    if (MinimumMazeSize <= mazeRows && mazeRows <= MaximumMazeSize
                        && MinimumMazeSize <= mazeColumns && mazeColumns <= MaximumMazeSize)
                    {
                        this.ResetGameVariables(mazeRows, mazeColumns);
                    }
                }
                else
                {
                    this.renderer.RenderText(InvalidArguments, this.cursorPositionLeft, this.cursorPositionTop - 1);
                }
            }
            else
            {
                this.ResetGameVariables();
            }

            this.RenderGameComponents();
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
        /// Prints the current scoreboard.
        /// </summary>
        private void HandleScoreCommand()
        {
            this.displayScoreboardCommand.Execute();

            Console.ReadKey();
            this.RenderGameComponents();
        }

        /// <summary>
        /// Changes player position.
        /// Prints current position.
        /// Displays Game Over message on reaching the exit.
        /// </summary>
        /// <param name="command">Name of command.</param>
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
                this.renderer.Clear(this.player);
                this.playerMoveCommand.Execute();
                this.renderer.Render(this.player);
                this.renderer.RenderText(this.blankLine, this.cursorPositionLeft, this.cursorPositionTop - 1);
            }
            else
            {
                this.renderer.RenderText(IllegalMove, this.cursorPositionLeft, this.cursorPositionTop - 1);
            }

            if (this.HasReachedTheExit())
            {
                this.HandleGameEnded();
            }
        }

        /// <summary>
        /// Checks if a given maze cell is available for the player to move to.
        /// </summary>
        /// <returns>A boolean variable representing the availability status of the cell.</returns>
        private bool IsPositionAvailable()
        {
            var position = this.player.TopLeftPosition + this.player.Direction;
            return !this.maze[position.Row, position.Col].IsWall;
        }

        /// <summary>
        /// Checks if the position the player is moving to is the exit.
        /// </summary>
        /// <returns>Player  HasReachedTheExit status.</returns>
        private bool HasReachedTheExit()
        {
            var position = this.player.TopLeftPosition;
            return this.maze[position.Row, position.Col].IsExit;
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        private void HandleExitCommand()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Generates new maze. Clears console and prints maze by given rows and cols.
        /// </summary>
        /// <param name="mazeRows">The rows of the maze to be generated.</param>
        /// <param name="mazeColumns">The columns of the maze to be generated.</param>
        private void ResetGameVariables(int mazeRows = DefaultMazeRows, int mazeColumns = DefaultMazeColumns)
        {
            this.maze.Generate(mazeRows, mazeColumns);

            this.player.TopLeftPosition = new MatrixCoordinates(
                this.maze.TopLeftPosition.Row + 1,
                this.maze.TopLeftPosition.Col + 1);

            this.cursorPositionLeft = 0;
            this.cursorPositionTop = this.maze.Rows + 2;
            this.steps = 0;
        }

        /// <summary>
        /// Gets player name and calculates score. 
        /// Updates scoreboard and restarts the game.
        /// </summary>
        private void HandleGameEnded()
        {
            var totalScore = (this.maze.Rows * this.maze.Columns) - this.steps;

            this.renderer.RenderText(
                string.Format(SuccessMessage, totalScore),
                this.cursorPositionLeft,
                this.cursorPositionTop - 1);

            var playerName = Console.ReadLine();
            this.scoreboard.UpdateScoreBoard(totalScore, playerName);

            this.ResetGameVariables(DefaultMazeRows, DefaultMazeColumns);

            this.scoreboard.UpdateScoreBoard(totalScore, playerName);
        }

        /// <summary>
        /// Renders the game environment.
        /// </summary>
        private void RenderGameComponents()
        {
            this.renderer.ClearAll();
            this.renderer.Render(this.maze);
            this.renderer.Render(this.player);
        }

        /// <summary>
        /// Executes maze generator by input.
        /// </summary>
        /// <param name="strategyName">Requested maze generator name.</param>
        private void HandleSetCommand(string strategyName)
        {
            strategyName = strategyName.ToLower();

            if (strategyName == BacktrackerStrategySubCommand)
            {
                this.setToBacktrackerCommand.Execute();
            }
            else if (strategyName == PrimStrategySubCommand)
            {
                this.setToPrimCommand.Execute();
            }

            var message = string.Format(StrategySwitchedMessage, strategyName);
            this.renderer.RenderText(this.blankLine, this.cursorPositionLeft, this.cursorPositionTop - 1);
            this.renderer.RenderText(message, this.cursorPositionLeft, this.cursorPositionTop - 1);
        }
    }
}