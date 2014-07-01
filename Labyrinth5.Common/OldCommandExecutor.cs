namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Mazes;

    public class OldCommandExecutor
    {
        //TODO: Reimplement when Maze, Player and Scoreboard classes are completed.
        private Player player;
        private Maze maze;
        private MazeCell[,] maze;
        private Scoreboard scoreboard;

        public OldCommandExecutor()
        {
            player = new Player();
            mazeContext = new Maze(new PrimMazeGenerator());
            maze = mazeContext.Generate(15,25);
            scoreboard = new Scoreboard();
        }

        private bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            if ((playerPositionX > 0 && playerPositionX < this.maze.GetLength(0) - 1) &&
                (playerPositionY > 0 && playerPositionY < this.maze.GetLength(1) - 1))
            {
                return false;
            }

            return true;
        }

        public void PlayGame()
        {
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                string currentLine = string.Empty;
                PrintMazeOnConsole();

                if (this.IsGameOver(this.player.Row, this.player.Column))
                {
                    Console.WriteLine("Congratulations! You've exited the labirynth in {0} moves.", movesCounter);
                    
                    //TODO: the  player name request is excluded from the scorebourd method,
                    //it should be requested in the command executor at the end of each game and 
                    // given as a parameter to the UpdateScoreBorad method

                    //scoreboard.UpdateScoreBoard(movesCounter);
                    scoreboard.PrintScore();
                    movesCounter = 0;
                    currentLine = "RESTART";
                }
                else
                {
                    Console.Write("Enter your move (L=left, R-right, U=up, D=down):");
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
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("**Press a key to continue**");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void PrintMazeOnConsole()
        {
            for (int r = 0; r < this.maze.GetLength(0); r++)
            {
                for (int c = 0; c < this.maze.GetLength(1); c++)
                {
                    Console.Write(maze[r,c].GetSymbol());
                }
                Console.WriteLine();
            }
        }
    }
}
