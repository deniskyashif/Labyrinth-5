namespace Labyrinth5.Common.MazeComponents
{
    using System;
    using Labyrinth5.Common.Contracts;

    internal class Maze : IRenderable
    {
        private const int DefaultLeftOffset = 0;
        private const int DefaultTopOffset = 0;

        private const char WallImage = '\u2593';
        private const char PathImage = ' ';
        private const char ExitImage = 'E';

        private IMazeGenerator strategy;
        private IMazeCell[,] maze;
        private MatrixCoordinates topLeftPosition;

        public Maze(IMazeGenerator generator)
            : this(generator, DefaultTopOffset, DefaultLeftOffset) 
        { 
        }

        public Maze(IMazeGenerator generator, int leftOffset, int topOffset)
        {
            this.strategy = generator;
            this.TopLeftPosition = new MatrixCoordinates(leftOffset, topOffset);
        }

        public MatrixCoordinates TopLeftPosition
        {
            get { return this.topLeftPosition; }
            set { this.topLeftPosition = value; }
        }

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
                    if (this.maze[row, col].IsExit)
                    {
                        mazeImage[row, col] = ExitImage;
                    }
                    else
                    {
                        if (this.maze[row, col].IsWall)
                        {
                            mazeImage[row, col] = WallImage;
                        }
                        else
                        {
                            mazeImage[row, col] = PathImage;
                        }
                    }
                }
            }

            return mazeImage;
        }
    }
}
