// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class processing the maze generation process. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents
{
    using System;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    ///   Class processing the maze generation process. 
    /// </summary>
    internal class Maze : IRenderable
    {
        private const int DefaultLeftOffset = 0;
        private const int DefaultTopOffset = 0;

        private const char WallImage = '\u2593';
        private const char PathImage = ' ';
        private const char ExitImage = 'E';

        private IMazeGenerator strategy;
        private IMazeCell[,] mazeCells;
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
            get { return this.mazeCells.GetLength(0); }
        }

        internal int Columns
        {
            get { return this.mazeCells.GetLength(1); }
        }

        internal IMazeGenerator GenerationStrategy
        {
            get
            {
                return this.strategy;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Maze generation strategy can't be null");
                }

                this.strategy = value;
            }
        }

        internal IMazeCell this[int row, int col]
        {
            get { return this.mazeCells[row, col]; }
        }

        public char[,] GetImage()
        {
            var mazeImage = new char[this.Rows, this.Columns];

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    if (this.mazeCells[row, col].IsExit)
                    {
                        mazeImage[row, col] = ExitImage;
                    }
                    else
                    {
                        if (this.mazeCells[row, col].IsWall)
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

        internal void Generate(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException("Maze can't have negative dimensions.");
            }

            this.mazeCells = this.GenerationStrategy.Generate(rows, columns);
        }
    }
}
