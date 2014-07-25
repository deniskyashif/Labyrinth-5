// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MazeCell.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class that creates and holds information for a single cell of the game maze.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents.Cells
{
    using System;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Internal class that creates and holds information for a single cell of the game maze.
    /// </summary>
    internal abstract class MazeCell : IMazeCell
    {
        /// <summary>
        /// Holds the position of the maze cell.
        /// </summary>
        private MatrixCoordinates position; 

        /// <summary>
        /// Initializes a new instance of the<see cref="MazeCell"/> class.
        /// </summary>
        /// <param name="row">Row position.</param>
        /// <param name="col">Col position.</param>
        protected internal MazeCell(int row, int col)
        {
            this.Position = new MatrixCoordinates(row, col);
            this.IsWall = true;
        }

        /// <summary>
        /// Gets or sets the position.
        /// Validates the input.
        /// </summary>
        public MatrixCoordinates Position 
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value.Row < 0 || value.Col < 0)
                {
                    throw new ArgumentOutOfRangeException("Maze cells' position can't consist of negative corrdinates.");
                }

                this.position = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a maze cell is a wall.
        /// </summary>
        public bool IsWall { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether a maze cell is a Exit.
        /// </summary>
        public bool IsExit { get; set; }
    }
}
