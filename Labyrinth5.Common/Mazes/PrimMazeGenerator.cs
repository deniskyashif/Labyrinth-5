namespace Labyrinth5.Common.Mazes
{
    using System;
    using System.Collections.Generic;
    
    internal class PrimMazeGenerator : IMazeGenerator
    {
        private static Random GlobalRandomGenerator = new Random();

        public MazeCell[,] Generate(int rows, int columns)
        {
            return this.CreateMaze(rows, columns);
        }

        private MazeCell[,] CreateMaze(int rows, int columns)
        {
            var maze = this.InitializeEmptyMaze(rows, columns);

            var currentCell = maze[rows / 2, columns / 2];
            currentCell.Type = CellType.Path;

            var frontiers = GetAdjacentWallCells(maze, currentCell);

            IList<MazeCell> adjacentWallCells;
            int currentCellIndex;

            while (frontiers.Count > 0)
            {
                currentCellIndex = GlobalRandomGenerator.Next(0, frontiers.Count);
                currentCell = frontiers[currentCellIndex];
                adjacentWallCells = GetAdjacentWallCells(maze, currentCell);

                if (currentCell.Type == CellType.Wall && adjacentWallCells.Count == 3)
                {
                    maze[currentCell.Row, currentCell.Col].Type = CellType.Path;
                    frontiers.AddRange(adjacentWallCells);
                }
                else
                {
                    frontiers.RemoveAt(currentCellIndex);
                }
            }

            return maze;
        }

        private List<MazeCell> GetAdjacentWallCells(MazeCell[,] maze, MazeCell cell) 
        {
            var neighbours = new List<MazeCell>();

            if (cell.Row - 1 >= 0 && maze[cell.Row - 1, cell.Col].Type == CellType.Wall)
            {
                neighbours.Add(maze[cell.Row - 1, cell.Col]);
            }
            if (cell.Row + 1 < maze.GetLength(0) && maze[cell.Row + 1, cell.Col].Type == CellType.Wall)
            {
                neighbours.Add(maze[cell.Row + 1, cell.Col]);
            }
            if (cell.Col - 1 >= 0 && maze[cell.Row, cell.Col - 1].Type == CellType.Wall)
            {
                neighbours.Add(maze[cell.Row, cell.Col - 1]);
            }
            if (cell.Col + 1 < maze.GetLength(1) && maze[cell.Row, cell.Col + 1].Type == CellType.Wall)
            {
                neighbours.Add(maze[cell.Row, cell.Col + 1]);
            }

            return neighbours;
        }

        private MazeCell[,] InitializeEmptyMaze(int rows, int columns)
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
    }
}
