// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
// An internal class which is used for creation of mazes(two-dimensional arrays of IMazeCell objects
// using the Iterative Backtracker algorithm.// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents.Generators
{
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;

    /// <summary>
    /// An internal class which is used for creation of mazes(two-dimensional arrays of IMazeCell objects
    /// using the Iterative Backtracker algorithm.
    /// </summary>
    internal class BacktrackerMazeGenerator : IMazeGenerator
    {
        private static readonly Random GlobalRandomGenerator = new Random();

        /// <summary>
        /// Delegates the generation procedure and returns the result.
        /// </summary>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of IMazeCell objects.</returns>
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
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of IMazeCell objects.</returns>
        private IMazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializeBacktrackerMaze(rows, columns);
            var pathSoFar = new Stack<BacktrackerCell>();
            var currentCell = maze[1, 1];
            
            do
            {
                maze[currentCell.Position.Row, currentCell.Position.Col].IsBacktracked = true;
                maze[currentCell.Position.Row, currentCell.Position.Col].IsWall = false;

                var unvisitedNeighbours = this.GetUnvisitedNeighbours(maze, currentCell);

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
            } 
            while (pathSoFar.Count > 0);

            this.SetExit(maze);
            return maze;
        }

        /// <summary>
        /// From given maze and coordinates correlating to a cell in maze,
        /// its adjacent cells, which are not backtracked yet, are extracted an returned as a collection.
        /// </summary>
        /// <param name="maze">Maze as two dimensional array of IMazeCell objects.</param>
        /// <param name="cell">IMazeCell object.</param>
        /// <returns>A collection of IMazeCell objects.</returns>
        private IList<BacktrackerCell> GetUnvisitedNeighbours(BacktrackerCell[,] maze, IMazeCell cell)
        {
            var unvisitedNeighbours = new List<BacktrackerCell>();
            var row = cell.Position.Row;
            var col = cell.Position.Col;

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

        /// <summary>
        /// Checks if a cell borders with exactly one path cell, having respectively the rest of its neighbours as walls.
        /// </summary>
        /// <param name="maze">Maze as two dimensional array of IMazeCell objects.</param>
        /// <param name="cell">IMazeCell object.</param>
        /// <returns>A boolean value, depending on whether the condition is fulfilled.</returns>
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

        /// <summary>
        /// Traverses the last maze column and marks the first path cell found as an exit.
        /// </summary>
        /// <param name="maze">Maze as two dimensional array of IMazeCell objects.</param>
        private void SetExit(IMazeCell[,] maze)
        {
            int row = maze.GetLength(0) - 2;
            int col = maze.GetLength(1) - 2;

            while (true)
            {
                if (!maze[row, col].IsWall)
                {
                    maze[row, col].IsExit = true;
                    break;
                }

                row--;
            }
        }

        /// <summary>
        /// Initializes two dimensional array of PrimCell objects,
        /// by given dimensions.
        /// </summary>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of IMazeCell objects.</returns>
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
