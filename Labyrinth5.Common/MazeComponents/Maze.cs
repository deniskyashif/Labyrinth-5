namespace Labyrinth5.Common.MazeComponents
{
    using System;
    using Labyrinth5.Common.Contracts;

    internal class Maze : IRenderable
    {
        private const int DefaultMazeRows = 15;
        private const int DefaultMazeColumns = 25;
        private const int DefaultLeftOffset = 0;
        private const int DefaultTopOffset = 0;

        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';
        private const char ExitSymbol = 'E';


        private IMazeGenerator strategy;
        private IMazeCell[,] maze;
        
        public Maze(IMazeGenerator generator)
            : this(generator, DefaultMazeRows, DefaultMazeColumns) 
        { 
        }

        public Maze(IMazeGenerator generator, int rows, int columns)
            : this(generator, rows, columns, DefaultLeftOffset, DefaultTopOffset)
        {
        }

        public Maze(IMazeGenerator generator, int rows, int columns, int leftOffset, int topOffset)
        {
            this.strategy = generator;
            this.Generate(rows, columns);
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
                        mazeImage[row, col] = ExitSymbol;
                    }
                    if (this.maze[row, col].IsWall)
                    {
                        mazeImage[row, col] = WallSymbol;
                    }
                    if (this.maze[row, col].IsExit)
                    {
                        mazeImage[row, col] = ExitSymbol;
                    }

                }
            }

            return mazeImage;
        }
    }
}
