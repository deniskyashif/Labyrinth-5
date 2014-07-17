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
        /// Constructor.Sets the position of the cell.
        /// </summary>
        /// <param name="row">Row position.</param>
        /// <param name="col">Col position.</param>
        protected internal MazeCell(int row, int col)
        {
            this.Position = new MatrixCoordinates(row, col);
            this.IsWall = true;
        }

        /// <summary>
        /// Gets the position.
        /// Sets the position by input and validates it.
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
        /// Holds the information on the availability of the cell for a player to move to it.
        /// </summary>
        public bool IsWall { get; set; }
        
        /// <summary>
        /// Holds the information whether the cell is the exit or not.
        /// </summary>
        public bool IsExit { get; set; }
    }
}
