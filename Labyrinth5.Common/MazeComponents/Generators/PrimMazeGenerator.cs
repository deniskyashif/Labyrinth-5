namespace Labyrinth5.Common.MazeComponents.Generators
{
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents.Cells;
    
    internal class PrimMazeGenerator : IMazeGenerator
    {
        private static readonly Random globalRandomGenerator = new Random();

        public IMazeCell[,] Generate(int rows, int columns)
        {
            return this.CreateMaze(rows, columns);
        }

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
                currentCellIndex = globalRandomGenerator.Next(0, frontiers.Count);
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
