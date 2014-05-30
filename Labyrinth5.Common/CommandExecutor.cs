namespace Labyrinth5.Common
{
    using System;

    public class CommandExecutor
    {


        private bool IsGameOver(int playerPositionX, int playerPositionY, Maze labyrinth)
        {
            if ((playerPositionX > 0 && playerPositionX < labyrinth.matrix.GetLength(0) - 1) &&
                (playerPositionY > 0 && playerPositionY < labyrinth.matrix.GetLength(1) - 1))
            {
                return false;
            }

            return true;
        }



        public void PlayGame(Player player, Maze labyrinth, Scoreboard scoreboard)
        {
            string command = string.Empty;
            int movesCounter = 0;
            while (command.Equals("EXIT") == false)
            {
                labyrinth.PrintLabirynth();
                string currentLine = string.Empty;

                if (this.IsGameOver(player.playerPositionX, player.playerPositionY, labyrinth))
                {
                    Console.WriteLine("Congratulations! You've exited the labirynth in {0} moves.", movesCounter);

                    scoreboard.UpdateScoreBoard(movesCounter);
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
                this.ExecuteCommand(command, ref movesCounter, player, labyrinth, scoreboard);
            }



        }

        private void ExecuteCommand(string command, ref int movesCounter, Player player, Maze labyrinth, Scoreboard scoreboard)
        {
            switch (command.ToUpper())
            {
                case "L":
                    {
                        movesCounter++;
                        player.Move(-1, 0, labyrinth);
                        break;
                    }
                case "R":
                    {
                        movesCounter++;
                        player.Move(1, 0, labyrinth);
                        break;
                    }
                case "U":
                    {
                        movesCounter++;
                        player.Move(0, -1, labyrinth);
                        break;
                    }
                case "D":
                    {
                        movesCounter++;
                        player.Move(0, 1, labyrinth);
                        break;
                    }
                case "RESTART":
                    {
                        player = new Player();
                        labyrinth = new Maze();

                        break;
                    }
                case "TOP":
                    {
                        scoreboard.PrintScore();
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
    }
}
