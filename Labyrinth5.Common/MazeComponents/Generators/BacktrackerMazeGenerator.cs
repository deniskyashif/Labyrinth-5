namespace Labyrinth5.Common.MazeComponents.Generators
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;
    using System;
    using System.Collections.Generic;

    internal class BacktrackerMazeGenerator : IMazeGenerator
    {
        private static readonly Random GlobalRandomGenerator = new Random();

        public IMazeCell[,] Generate(int rows, int columns)
        {
            return this.CreateMaze(rows, columns);
        }

        /// <summary>
        /// Generates random maze using iterative Depth First Search algorithm. From a specified entry point
        /// in the matrix of MazeCell objects(initially all cells marked as walls), 
        /// an unvisited neigbour cell is randomly chosen, if it has only one neighbour that is a path cell - 
        /// that cell is made a path and pushed into the stack, otherwise the algorithms "tracks back" popping
        /// cells out of the stack until it reaches one that satisfies the condition.
        /// The process goes on until there are no cells left in the stack.
        /// </summary>
        /// <param name="entryRow">Enrty cell row.</param>
        /// <param name="entryCol">Entry cell column.</param>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of MazeCell objects.</returns>
        private IMazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializeBacktrackerMaze(rows, columns);
            var pathSoFar = new Stack<BacktrackerCell>();
            var currentCell = maze[rows / 2, columns / 2];

            do
            {
                maze[currentCell.Position.Row, currentCell.Position.Col].IsBacktracked = true;
                maze[currentCell.Position.Row, currentCell.Position.Col].IsWall = false;

                var unvisitedNeighbours = this.GetUnvisitedNeighbours(maze, currentCell.Position.Row, currentCell.Position.Col);

                if (unvisitedNeighbours.Count > 0)
                {
                    var nextCellIndex = GlobalRandomGenerator.Next(0, unvisitedNeighbours.Count);
                    var nextCell = unvisitedNeighbours[nextCellIndex];

                    if (this.HasOnlyOneAdjacentPathCell(maze, nextCell))
                    {
                        pathSoFar.Push(currentCell);
                        currentCell = nextCell;
                    }
                    else
                    {
                        maze[nextCell.Position.Row, nextCell.Position.Col].IsBacktracked = true;
                    }
                }
                else
                {
                    currentCell = pathSoFar.Pop();
                }
            } while (pathSoFar.Count > 0);

            return maze;
        }

        private IList<BacktrackerCell> GetUnvisitedNeighbours(BacktrackerCell[,] maze, int row, int col)
        {
            var unvisitedNeighbours = new List<BacktrackerCell>();

            if (row - 1 >= 1 && !maze[row - 1, col].IsBacktracked)
            {
                unvisitedNeighbours.Add(maze[row - 1, col]);
            }

            if (row + 1 < maze.GetLength(0) - 1 && !maze[row + 1, col].IsBacktracked)
            {
                unvisitedNeighbours.Add(maze[row + 1, col]);
            }

            if (col - 1 >= 1 && !maze[row, col - 1].IsBacktracked)
            {
                unvisitedNeighbours.Add(maze[row, col - 1]);
            }

            if (col + 1 < maze.GetLength(1) - 1 && !maze[row, col + 1].IsBacktracked)
            {
                unvisitedNeighbours.Add(maze[row, col + 1]);
            }

            return unvisitedNeighbours;
        }

        private bool HasOnlyOneAdjacentPathCell(IMazeCell[,] maze, IMazeCell cell)
        {
            int adjacentPathCells = 0;

            if (cell.Position.Row - 1 >= 0 && !maze[cell.Position.Row - 1, cell.Position.Col].IsWall)
            {
                adjacentPathCells++;
            }

            if (cell.Position.Row + 1 < maze.GetLength(0) && !maze[cell.Position.Row + 1, cell.Position.Col].IsWall)
            {
                adjacentPathCells++;
            }

            if (cell.Position.Col - 1 >= 0 && !maze[cell.Position.Row, cell.Position.Col - 1].IsWall)
            {
                adjacentPathCells++;
            }

            if (cell.Position.Col + 1 < maze.GetLength(1) && !maze[cell.Position.Row, cell.Position.Col + 1].IsWall)
            {
                adjacentPathCells++;
            }

            return adjacentPathCells == 1;
        }

        private BacktrackerCell[,] InitializeBacktrackerMaze(int rows, int columns)
        {
            var maze = new BacktrackerCell[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    maze[row, col] = new BacktrackerCell(row, col);
                }
            }

            return maze;
        }
    }
}
