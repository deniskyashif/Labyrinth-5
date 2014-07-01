namespace Labyrinth5.Common.MazeComponents.Generators
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;
    using System;
    using System.Collections.Generic;
    
    public class PrimMazeGenerator : IMazeGenerator
    {
        private static Random GlobalRandomGenerator = new Random();

        public IMazeCell[,] Generate(int rows, int columns)
        {
            return this.CreateMaze(rows, columns);
        }

        private IMazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializePrimMaze(rows, columns);

            var currentCell = maze[rows / 2, columns / 2];
            currentCell.IsWall = false;

            var frontiers = GetAdjacentWallCells(maze, currentCell);

            IList<IMazeCell> adjacentWallCells;
            int currentCellIndex;

            while (frontiers.Count > 0)
            {
                currentCellIndex = GlobalRandomGenerator.Next(0, frontiers.Count);
                currentCell = frontiers[currentCellIndex];
                adjacentWallCells = GetAdjacentWallCells(maze, currentCell);

                if (currentCell.IsWall && adjacentWallCells.Count == 3)
                {
                    maze[currentCell.Row, currentCell.Col].IsWall = false;
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

            if (cell.Row - 1 >= 0 && maze[cell.Row - 1, cell.Col].IsWall)
            {
                neighbours.Add(maze[cell.Row - 1, cell.Col]);
            }
            if (cell.Row + 1 < maze.GetLength(0) && maze[cell.Row + 1, cell.Col].IsWall)
            {
                neighbours.Add(maze[cell.Row + 1, cell.Col]);
            }
            if (cell.Col - 1 >= 0 && maze[cell.Row, cell.Col - 1].IsWall)
            {
                neighbours.Add(maze[cell.Row, cell.Col - 1]);
            }
            if (cell.Col + 1 < maze.GetLength(1) && maze[cell.Row, cell.Col + 1].IsWall)
            {
                neighbours.Add(maze[cell.Row, cell.Col + 1]);
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
