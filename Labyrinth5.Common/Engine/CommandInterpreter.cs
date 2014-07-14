namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.Engine.Commands;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;
    using System;

    internal class CommandInterpreter : ICommandInterpreter
    {
        private const int MinimumMazeSize = 10;
        private const int MaximumMazeSize = 60;
        private const int DefaultMazeRows = 15;
        private const int DefaultMazeColumns = 20;

        private readonly string blankLine = new string(' ', Console.WindowWidth);
        private readonly char[] separators = new char[] { ' ' };
        
        private readonly IRenderer renderer = new ConsoleRenderer();
        private readonly Player player = new Player();
        private readonly Maze maze = new Maze(new BacktrackerMazeGenerator());

        private readonly ICommand playerMoveCommand;
        private readonly ICommand displayInstructionsCommand;
       
        private int cursorPositionLeft;
        private int cursorPositionTop;
        //TODO: Implement score calculation 
        //TODO: Implement custom game options as command
        //TODO: (optional) Implement maze solver command
        
        public CommandInterpreter()
        {
            this.playerMoveCommand = new PlayerMoveCommand(player);
            this.displayInstructionsCommand = new DisplayInstructionsCommand(renderer);
        }

        public void ParseAndDispatch(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                var commandWords = command.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (commandWords[0] == "init")
                {
                    this.HandleInitCommand(commandWords);
                }
                if (commandWords[0] == "info")
                {
                    this.HandleInfoCommand();
                }
                else if ((commandWords[0] == "m" || commandWords[0] == "move") && commandWords.Length > 1)
                {
                    this.HandleMoveCommand(commandWords[1]);
                }
            }

            renderer.RenderText(blankLine, this.cursorPositionLeft, this.cursorPositionTop);
            Console.SetCursorPosition(this.cursorPositionLeft, this.cursorPositionTop);
        }

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
            }
            else
            {
                this.SetUpGame(DefaultMazeRows, DefaultMazeColumns);
            }
        }

        private void HandleInfoCommand()
        {
            this.displayInstructionsCommand.Execute();
            Console.ReadKey();
            this.renderer.ClearAll();
            this.renderer.Render(maze);
            this.renderer.Render(player);
        }

        private void HandleMoveCommand(string command)
        {
            this.renderer.Clear(player);

            if (command == "w" || command == "up")
            {
                this.player.Direction = Directions.Up;
            }
            else if (command == "d" || command == "right")
            {
                this.player.Direction = Directions.Right;
            }
            else if (command == "s" || command == "down")
            {
                this.player.Direction = Directions.Down;
            }
            else if (command == "a" || command == "left")
            {
                this.player.Direction = Directions.Left;
            }

            if (this.IsPositionAvailable())
            {
                this.playerMoveCommand.Execute();
            }

            this.renderer.Render(player);

            if (this.HasReachedTheExit())
            {
                //TODO: Implement proper end game method
                renderer.RenderText("Success!", this.cursorPositionLeft, this.cursorPositionTop + 1);
                Console.ReadKey();
                this.SetUpGame(DefaultMazeRows, DefaultMazeColumns);
            }
        }

        private void SetUpGame(int mazeRows, int mazeColumns)
        {
            this.maze.Generate(mazeRows, mazeColumns);

            this.player.TopLeftPosition = new MatrixCoordinates(
                this.maze.TopLeftPosition.Row + 1,
                this.maze.TopLeftPosition.Col + 1);

            this.cursorPositionLeft = 0;
            this.cursorPositionTop = this.maze.Rows + 1;
            
            this.renderer.ClearAll();
            this.renderer.Render(maze);
            this.renderer.Render(player);
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
    }
}