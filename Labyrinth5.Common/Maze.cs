namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;
    
    public class Maze
    {
        private const char BlockedCellSymbol = '\u2593';
        private const char AvailableCellSymbol = '\u00a0';
        private const char PlayerSymbol = '\u263a';

        private const int MazeRows = 10;
        private const int MazeColumns = 10;
        private const int MinimumPercentageOfBlockedCells = 30;
        private const int MaximumPercentageOfBlockedCells = 50;

        private char[,] mazeCells;
        
        public Maze()
        {
            this.mazeCells = this.GenerateMatrix();
        }

        public int Rows
        {
            get
            {
                return this.mazeCells.GetLength(0);
            } 
        }

        public int Columns
        {
            get
            {
                return this.mazeCells.GetLength(1);
            }
        }

        public bool IsCellAvailable(int row, int column)
        {
            return this.mazeCells[row, column] == AvailableCellSymbol;
        }

        public void MarkCellAsAvailable(int row, int column)
        {
            this.mazeCells[row, column] = AvailableCellSymbol;
        }

        public void MarkCellAsOccupied(int row, int column) 
        {
            this.mazeCells[row, column] = PlayerSymbol;
        }

        public void PrintMazeOnConsole()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    Console.Write("{0}", this.mazeCells[row, col]);
                }

                Console.WriteLine();
            }
        }

        //TODO: Implement proper maze generation algorithm
        
        //TODO: following bulk code - remove/refactor
        
        private char[,] GenerateMatrix()
        { 
            char[,] generatedMatrix = new char[MazeColumns, MazeColumns];
            Random rand = new Random();
            int percentageOfBlockedCells = rand.Next(MinimumPercentageOfBlockedCells, MaximumPercentageOfBlockedCells);

            for (int row = 0; row < MazeColumns; row++)
            {
                for (int col = 0; col < MazeColumns; col++)
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
                    if (pathX + dirX[num] >= 0 && pathX + dirX[num] < MazeColumns && pathY + dirY[num] >= 0 &&
                        pathY + dirY[num] < MazeColumns)
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

        private bool IsGameOver(int playerPositionX, int playerPositionY)
        {
            return true;
            if ((playerPositionX > 0 && playerPositionX < this.mazeCells.GetLength(0) - 1) &&
                (playerPositionY > 0 && playerPositionY < this.mazeCells.GetLength(1) - 1))
            {
                return false;
            }

            return true;
        }
    }
}
