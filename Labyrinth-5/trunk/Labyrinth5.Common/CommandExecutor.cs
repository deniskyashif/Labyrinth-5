namespace Labyrinth5.Common
{
    using System;

    public class CommandExecutor
    {
        //TODO: Reimplement when Maze, Player and Scoreboard classes are completed.
        private Player player;
        private Maze maze;
        private Scoreboard scoreboard;

        public CommandExecutor()
        {
            player = new Player();
            maze = new Maze();
            scoreboard = new Scoreboard();
        }

        private bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < this.maze.Rows - 1) &&
                (playerPositionY > 0 && playerPositionY < this.maze.Columns - 1))
            {
                return false;
            }

            return true;
        }

        public void PlayGame()
        {
            Console.WriteLine(GameMessage.WELCOME);

            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                maze.PrintMazeOnConsole(player);
                string currentLine = string.Empty;

                if (this.IsGameOver(this.player.Row, this.player.Column))
                {
                    Console.WriteLine(GameMessage.WIN, movesCounter);

                    scoreboard.UpdateScoreBoard(movesCounter);
                    scoreboard.PrintScore();
                    movesCounter = 0;
                    currentLine = "RESTART";
                }
                else
                {
                    Console.Write(GameMessage.AskForMove);
                    currentLine = Console.ReadLine();
                }
                if (currentLine == string.Empty)
                {
                    continue;
                }

                command = currentLine.ToUpper();
                this.ExecuteCommand(command, ref movesCounter);
            }
        }

        private void ExecuteCommand(string command, ref int movesCounter)
        {
            switch (command.ToUpper())
            {
                case "L":
                    {
                        movesCounter++;
                        //player.Move(-1, 0, this.maze);
                        break;
                    }
                case "R":
                    {
                        movesCounter++;
                        //player.Move(1, 0, this.maze);
                        break;
                    }
                case "U":
                    {
                        movesCounter++;
                        //player.Move(0, -1, this.maze);
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        //player.Move(0, 1, this.maze);
                        break;
                    }
                case "RESTART":
                    {
                        this.player = new Player();
                        //this.maze = new MazeGenerator();

                        break;
                    }
                case "TOP":
                    {
                        this.scoreboard.PrintScore();
                        break;
                    }
                case "EXIT":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine(GameMessage.InvalidInput);
                        Console.WriteLine(GameMessage.PresKey);
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}
