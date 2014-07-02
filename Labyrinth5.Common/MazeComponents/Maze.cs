namespace Labyrinth5.Common.MazeComponents
{
    using System;
    using Labyrinth5.Common.Contracts;

    internal class Maze : IRenderable
    {
        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';

        private IMazeGenerator strategy;
        private IMazeCell[,] maze;

        public Maze(IMazeGenerator generator)
        {
            this.strategy = generator;
            this.TopLeftPosition = new MatrixCoordinates(0, 0);
        }

        public MatrixCoordinates TopLeftPosition { get; set; }

        internal int Rows 
        { 
            get { return this.maze.GetLength(0); } 
        }

        internal int Columns 
        { 
            get { return this.maze.GetLength(1); } 
        }

        internal IMazeCell this[int row, int col] 
        { 
            get { return this.maze[row, col]; } 
        }

        internal void SetStrategy(IMazeGenerator generator)
        {
            this.strategy = generator;
        }

        internal void Generate(int rows, int columns) 
        {
            this.maze = this.strategy.Generate(rows, columns);
        }

        public char[,] GetImage()
        {
            var mazeImage = new char[this.Rows, this.Columns];

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    mazeImage[row, col] = this.maze[row, col].IsWall ? WallSymbol: PathSymbol;
                }
            }

            return mazeImage;
        }
    }
}
