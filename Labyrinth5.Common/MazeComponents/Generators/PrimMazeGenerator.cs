// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrimMazeGenerator.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
// An internal class which is used for creation of mazes(two-dimensional arrays of IMazeCell objects
// using the Prim's algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents.Generators
{
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;

    /// <summary>
    /// An internal class which is used for creation of mazes(two-dimensional arrays of IMazeCell objects
    /// using the Prim's algorithm.
    /// </summary>
    internal class PrimMazeGenerator : IMazeGenerator
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
        /// Generates random maze, using Prim's algorithm. A specified entry point
        /// in the matrix of MazeCell objects(initially all cells marked as walls), 
        /// is made a path and its its adjacent wall cells(serving as frontiers) are added to the 
        /// the "frontiers" collection. Then while there are available frontiers, a random one is chosen and marked
        /// as current cell - if it is surrounded by walls, i.e. neighbors with no less than three wall cells - 
        /// it is made a path and its neighbors are marked as frontiers. The process continues until there are no
        /// more frontiers left.
        /// </summary>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of IMazeCell objects.</returns>
        private IMazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializePrimMaze(rows, columns);

            var currentCell = maze[1, 1];
            currentCell.IsWall = false;
            
            var frontiers = this.GetAdjacentWallCells(maze, currentCell);

            IList<IMazeCell> adjacentWallCells;
            int currentCellIndex;

            while (frontiers.Count > 0)
            {
                currentCellIndex = GlobalRandomGenerator.Next(0, frontiers.Count);
                currentCell = frontiers[currentCellIndex];
                adjacentWallCells = this.GetAdjacentWallCells(maze, currentCell);

                if (currentCell.IsWall && adjacentWallCells.Count == 3)
                {
                    maze[currentCell.Position.Row, currentCell.Position.Col].IsWall = false;
                    frontiers.AddRange(adjacentWallCells);
                }
                else
                {
                    frontiers.RemoveAt(currentCellIndex);
                }
            }

            this.SetExit(maze);
            return maze;
        }

        /// <summary>
        /// From given maze and cell, whose coordinates correlate to a cell in maze,
        /// its adjacent cells of type wall extracted an returned.
        /// </summary>
        /// <param name="maze">Maze as two dimensional array of IMazeCell objects.</param>
        /// <param name="cell">IMazeCell object.</param>
        /// <returns>A collection of IMazeCell objects.</returns>
        private List<IMazeCell> GetAdjacentWallCells(IMazeCell[,] maze, IMazeCell cell) 
        {
            var neighbours = new List<IMazeCell>();

            if (cell.Position.Row - 1 >= 0 && maze[cell.Position.Row - 1, cell.Position.Col].IsWall)
            {
                neighbours.Add(maze[cell.Position.Row - 1, cell.Position.Col]);
            }

            if (cell.Position.Row + 1 < maze.GetLength(0) && maze[cell.Position.Row + 1, cell.Position.Col].IsWall)
            {
                neighbours.Add(maze[cell.Position.Row + 1, cell.Position.Col]);
            }

            if (cell.Position.Col - 1 >= 0 && maze[cell.Position.Row, cell.Position.Col - 1].IsWall)
            {
                neighbours.Add(maze[cell.Position.Row, cell.Position.Col - 1]);
            }

            if (cell.Position.Col + 1 < maze.GetLength(1) && maze[cell.Position.Row, cell.Position.Col + 1].IsWall)
            {
                neighbours.Add(maze[cell.Position.Row, cell.Position.Col + 1]);
            }

            return neighbours;
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
        private IMazeCell[,] InitializePrimMaze(int rows, int columns)
        {
            var maze = new PrimCell[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    maze[row, col] = new PrimCell(row, col);
                }
            }

            return maze;
        }
    }
}
