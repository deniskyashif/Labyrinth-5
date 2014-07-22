namespace Labyrinth5.Tests.MazeTests
{
    using System;
    using Labyrinth5.Common;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Cells;
    using Labyrinth5.Common.MazeComponents.Generators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth5.Common.Contracts;

    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        public void CheckIfTopLeftRowPositionIsCorrect()
        {
            BacktrackerMazeGenerator generator = new BacktrackerMazeGenerator();
            Maze maze = new Maze(generator, 10, 10);
            Assert.AreEqual(10, maze.TopLeftPosition.Row);
        }

        [TestMethod]
        public void CheckIfTopLeftColPositionIsCorrect()
        {
            BacktrackerMazeGenerator generator = new BacktrackerMazeGenerator();
            Maze maze = new Maze(generator, 20, 20);
            Assert.AreEqual(20, maze.TopLeftPosition.Row);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfNegativePrimcellCoordinatesThrowException()
        {
            PrimCell primcell = new PrimCell(-2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfNegativeBacktrackercellCoordinatesThrowException()
        {
            BacktrackerCell backtrackerCell = new BacktrackerCell(-3, -3);
        }

        [TestMethod]
        public void CheckIfBacktrackerMazeIsSolvable()
        {
            var maze = new Maze(new BacktrackerMazeGenerator());
            maze.Generate(20, 20);
            Assert.IsTrue(IsMazeSolvable(maze));
        }

        [TestMethod]
        public void CheckIfPrimMazeIsSolvable()
        {
            var maze = new Maze(new PrimMazeGenerator());
            maze.Generate(20, 20);
            Assert.IsTrue(IsMazeSolvable(maze));
        }

        private static bool IsMazeSolvable(Maze maze)
        {
            var grid = GetMazeAsGridOfIntegers(maze);
            var passableAreas = 0;
            var hasExit = false;

            for (int row = 1; row < grid.GetLength(0); row++)
            {
                for (int col = 1; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] != 1)    //i.e. cell is either path or exit
                    {
                        if (grid[row, col] == 2)
                        {
                            hasExit = true;
                            
                        }
                        else
                        {
                            passableAreas++;
                            TraverseAndMark(grid, row, col);
                        }
                    }
                }
            }

            return (passableAreas == 1) && hasExit;
        }

        private static void TraverseAndMark(int[,] grid, int row, int col)
        {
            if (IsInGrid(grid, row, col) && grid[row, col] != 1)
            {
                if(grid[row,col] == 0)
                { 
                    grid[row, col] = 1;
                }

                TraverseAndMark(grid, row + 1, col);
                TraverseAndMark(grid, row - 1, col);
                TraverseAndMark(grid, row, col + 1);
                TraverseAndMark(grid, row, col - 1);
            }
        }

        private static bool IsInGrid(int[,] grid, int row, int col)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        private static int[,] GetMazeAsGridOfIntegers(Maze maze)
        {
            var mazeAsGridOfIntegers = new int[maze.Rows, maze.Columns];

            for (int row = 0; row < maze.Rows; row++)
            {
                for (int col = 0; col < maze.Columns; col++)
                {
                    if (maze[row, col].IsExit)
                    {
                        mazeAsGridOfIntegers[row, col] = 2;
                    }
                    else if (maze[row, col].IsWall)
                    {
                        mazeAsGridOfIntegers[row, col] = 1;
                    }
                    else
                    {
                        mazeAsGridOfIntegers[row, col] = 0;
                    }
                }
            }

            return mazeAsGridOfIntegers;
        }
    }
}
