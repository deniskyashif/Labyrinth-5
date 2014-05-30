namespace Labyrinth5.Common
{
    using System;
    
    public class Maze
    {
        private const char BlockedCellSymbol = 'X';
        private const char AvailableCellSymbol = '-';
        private const char PlayerSymbol = '*';
        private const int LabyrinthSize = 7;
        private const int MinimumPercentageOfBlockedCells = 30;
        private const int MaximumPercentageOfBlockedCells = 50;

        public char[,] matrix;
        
        public Maze()
        {
            this.matrix = this.GenerateMatrix();
        }

        public void PrintLabirynth()
        {
            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int col = 0; col < LabyrinthSize; col++)
                {
                    Console.Write("{0,2}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private char[,] GenerateMatrix()
        { 
            char[,] generatedMatrix = new char[LabyrinthSize, LabyrinthSize];
            Random rand = new Random();
            int percentageOfBlockedCells = rand.Next(MinimumPercentageOfBlockedCells, MaximumPercentageOfBlockedCells);

            for (int row = 0; row < LabyrinthSize; row++)
            {
                for (int col = 0; col < LabyrinthSize; col++)
                {
                    int num = rand.Next(0, 100);
                    if (num < percentageOfBlockedCells)
                    {
                        generatedMatrix[row, col] = BlockedCellSymbol;
                    }
                    else
                    {
                        generatedMatrix[row, col] = AvailableCellSymbol;
                    }

                }
            }
            generatedMatrix[3, 3] = PlayerSymbol;

            this.MakeAtLeastOneExitReachable(generatedMatrix);
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top");
            Console.WriteLine("scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            return generatedMatrix;
        }

        private void MakeAtLeastOneExitReachable(char[,] generatedMatrix)
        {
            Random rand = new Random();
            int pathX = 3;
            int pathY = 3;
            int[] dirX = { 0, 0, 1, -1 };
            int[] dirY = { 1, -1, 0, 0 };
            int numberOfDirections = 4;
            int maximumTimesToChangeAfter = 2;

            while (this.IsGameOver(pathX , pathY) == false)
            {
                int num = rand.Next(0, numberOfDirections);
                int times = rand.Next(0, maximumTimesToChangeAfter);

                for (int d = 0; d < times; d++)
                {
                    if (pathX + dirX[num] >= 0 && pathX + dirX[num] < LabyrinthSize && pathY + dirY[num] >= 0 &&
                        pathY + dirY[num] < LabyrinthSize)
                    {


                        pathX += dirX[num];



                        pathY += dirY[num];
                        if (generatedMatrix[pathY, pathX] == PlayerSymbol)
                        {
                            continue;
                        }
                        generatedMatrix[pathY, pathX] = AvailableCellSymbol;
                    }
                }
            }
        }
    }
}
