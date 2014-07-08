namespace Labyrinth5.Common.MazeComponents.Generators
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;
    using System;
    using System.Collections.Generic;
    
    internal class PrimMazeGenerator : IMazeGenerator
    {
        private static Random GlobalRandomGenerator = new Random();

        public IMazeCell[,] Generate(int rows, int columns)
        {
            return this.CreateMaze(rows, columns);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="http://en.wikipedia.org/wiki/Maze_generation_algorithm#Randomized_Prim.27s_algorithm"/>
        /// <param name="rows">Maze width, as number of rows.</param>
        /// <param name="columns">Maze height as number of columns.</param>
        /// <returns>Maze as two dimensional array of MazeCell objects.</returns>
        private IMazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializePrimMaze(rows, columns);

            var currentCell = maze[rows - 2, columns - 2];
            currentCell.IsWall = false;
            currentCell.IsExit = true;

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

            return maze;
        }

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
