namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;

    internal static class MazeGenerator
    {
        private const int DefaultRows = 15;
        private const int DefaultColumns = 25;
        private const int DefaultEntryRow = 0;
        private const int DefaultEntryColumn = 0;
       
        private const char BorderSymbol = '\u2593';

        private static readonly Random GlobalRandomGenerator = new Random();

        internal static MazeCell[,] GenerateRandomMaze()
        {
            return GenerateRandomMaze(DefaultRows, DefaultColumns, DefaultEntryRow, DefaultEntryColumn);
        }

        internal static MazeCell[,] GenerateRandomMazeByGivenSize(int rows, int columns)
        {
            return GenerateRandomMaze(rows, columns, DefaultEntryRow, DefaultEntryColumn);
        }

        internal static MazeCell[,] GenerateRandomMazeByGivenSizeAndEntryCell(int rows, int columns, int entryRow, int entryCol)
        {
            return GenerateRandomMaze(rows, columns, entryRow, entryCol);
        }
        
        //TODO (Note): might be shifted on the Command Executor
        internal static void PrintMazeOnConsole(MazeCell[,] maze)
        {
            Console.WriteLine(new string(BorderSymbol, maze.GetLength(1) + 2));

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.Write(BorderSymbol);

                for (int col = 0; col < maze.GetLength(1); col++)
                { 
                    Console.Write(maze[row, col]);
                }

                Console.Write(BorderSymbol);
                Console.WriteLine();
            }

            Console.WriteLine(new string(BorderSymbol, maze.GetLength(1) + 2));
        }

        /// <summary>
        /// Generates random maze using iterative Depth First Search algorithm. From a specified entry point
        /// in the matrix of MazeCell objects(initially all cells marked as walls), 
        /// an unvisited neigbour cell is randomly chosen, then it is marked as visited.
        /// If it has less than two neighbours that are path cells - that cell is made a path.
        /// The process goes on until there is no unvisited cell. 
        /// When so, the algorithms "tracks back" until it finds an unvisited cell. If there is no such cell, 
        /// it assumes that the maze is complete.
        /// </summary>
        /// <param name="entryRow">Enrty cell row.</param>
        /// <param name="entryCol">Entry cell column.</param>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of MazeCell objects.</returns>
        private static MazeCell[,] GenerateRandomMaze(int rows, int columns, int entryRow, int entryCol)
        {
            var generatedMaze = InitializeEmptyMaze(rows, columns);
            var pathSoFar = new Stack<MazeCell>();
            var currCell = generatedMaze[entryRow, entryCol];

            do
            {
                generatedMaze[currCell.Row, currCell.Col].IsVisited = true;
                generatedMaze[currCell.Row, currCell.Col].Type = CellType.Path;

                var unvisitedNeighbours = GetUnvisitedNeighbours(generatedMaze, currCell.Row, currCell.Col);

                if (unvisitedNeighbours.Count > 0)
                {
                    var nextCellIndex = GlobalRandomGenerator.Next(0, unvisitedNeighbours.Count);
                    var nextCell = unvisitedNeighbours[nextCellIndex];

                    if (HasLessThanTwoNeighbouringPathCells(generatedMaze, nextCell))
                    {
                        pathSoFar.Push(currCell);
                        currCell = nextCell;
                    }
                    else
                    {
                        generatedMaze[nextCell.Row, nextCell.Col].IsVisited = true;
                    }
                }
                else
                {
                    currCell = pathSoFar.Pop();
                }
            } while (pathSoFar.Count > 0);

            generatedMaze[entryRow, entryCol].Type = CellType.Entrance;
            int exitRow = rows - 1 - entryRow;
            int exitCol = columns - 1 - entryCol;
            generatedMaze[exitRow, exitCol].Type = CellType.Exit;

            return generatedMaze;
        }

        private static MazeCell[,] InitializeEmptyMaze(int rows, int columns)
        {
            var maze = new MazeCell[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    maze[row, col] = new MazeCell(row, col);
                }
            }

            return maze;
        }

        private static IList<MazeCell> GetUnvisitedNeighbours(MazeCell[,] maze, int row, int col)
        {
            var unvisitedNeighbours = new List<MazeCell>();

            if (row - 1 >= 0 && !maze[row - 1, col].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row - 1, col]);
            }

            if (row + 1 < maze.GetLength(0) && !maze[row + 1, col].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row + 1, col]);
            }

            if (col - 1 >= 0 && !maze[row, col - 1].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row, col - 1]);
            }

            if (col + 1 < maze.GetLength(1) && !maze[row, col + 1].IsVisited)
            {
                unvisitedNeighbours.Add(maze[row, col + 1]);
            }

            return unvisitedNeighbours;
        }

        private static bool HasLessThanTwoNeighbouringPathCells(MazeCell[,] maze, MazeCell nextCell)
        {
            int neighbouringPaths = 0;

            if (nextCell.Row - 1 >= 0 && maze[nextCell.Row - 1, nextCell.Col].Type != CellType.Wall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Row + 1 < maze.GetLength(0) && maze[nextCell.Row + 1, nextCell.Col].Type != CellType.Wall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Col - 1 >= 0 && maze[nextCell.Row, nextCell.Col - 1].Type != CellType.Wall)
            {
                neighbouringPaths++;
            }

            if (nextCell.Col + 1 < maze.GetLength(1) && maze[nextCell.Row, nextCell.Col + 1].Type != CellType.Wall)
            {
                neighbouringPaths++;
            }

            return neighbouringPaths <= 1;
        }
    }
}
