// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Maze.cs" company="Team-Labyrint5">
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
        /// <summary>
        /// Default left coordinate of the maze.
        /// </summary>
        private const int DefaultLeftOffset = 0;

        /// <summary>
        /// Default top coordinate of the maze.
        /// </summary>
        private const int DefaultTopOffset = 0;

        /// <summary>
        /// Char representing the wall cells when the maze is rendered.
        /// </summary>
        private const char WallImage = '\u2593';

        /// <summary>
        /// Char representing the path cells when the maze is rendered.
        /// </summary>
        private const char PathImage = ' ';

        /// <summary>
        /// Char representing the exit cell when the maze is rendered.
        /// </summary>
        private const char ExitImage = 'E';

        /// <summary>
        /// The algorithm for generating the maze.
        /// </summary>
        private IMazeGenerator strategy;

        /// <summary>
        /// Matrix of MazeCell object. 
        /// </summary>
        private IMazeCell[,] mazeCells;

        /// <summary>
        /// Holds the position of the maze for rendering.
        /// </summary>
        private MatrixCoordinates topLeftPosition;

        /// <summary>
        /// Initializes a new instance of the<see cref="Maze"/> class.
        /// </summary>
        /// <param name="generator">Maze Generator algorithm.</param>
        public Maze(IMazeGenerator generator)
            : this(generator, DefaultTopOffset, DefaultLeftOffset) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the<see cref="Maze"/> class.
        /// Sets a position of the maze by input.
        /// </summary>
        /// <param name="generator">Maze Generator algorithm.</param>
        /// <param name="leftOffset">New left coordinate.</param>
        /// <param name="topOffset">New top coordinate.</param>
        public Maze(IMazeGenerator generator, int leftOffset, int topOffset)
        {
            this.strategy = generator;
            this.TopLeftPosition = new MatrixCoordinates(leftOffset, topOffset);
        }

        /// <summary>
        /// Gets or sets the position for rendering.
        /// </summary>
        public MatrixCoordinates TopLeftPosition
        {
            get 
            { 
                return this.topLeftPosition; 
            }
            
            set 
            { 
                this.topLeftPosition = value; 
            }
        }

        /// <summary>
        /// Gets the number of rows of the maze matrix.
        /// </summary>
        internal int Rows
        {
            get 
            { 
                return this.mazeCells.GetLength(0); 
            }
        }

        /// <summary>
        /// Gets the number of cols of the maze matrix.
        /// </summary>
        internal int Columns
        {
            get 
            { 
                return this.mazeCells.GetLength(1); 
            }
        }

        /// <summary>
        /// Gets or sets the maze generator algorithm.
        /// Validates the input.
        /// </summary>
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

        /// <summary>
        /// Gets maze cell coordinates.
        /// </summary>
        /// <param name="row"> Row coordinate.</param>
        /// <param name="col"> Col coordinate.</param>
        /// <returns>Maze cell position.</returns>
        internal IMazeCell this[int row, int col]
        {
            get 
            { 
                return this.mazeCells[row, col]; 
            }
        }

        /// <summary>
        /// Implements IRenderable.
        /// </summary>
        /// <returns>Char matrix representation of the maze components.</returns>
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

        /// <summary>
        /// Generates the maze by the maze generator algorithm.
        /// Validates the input.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of cols.</param>
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
