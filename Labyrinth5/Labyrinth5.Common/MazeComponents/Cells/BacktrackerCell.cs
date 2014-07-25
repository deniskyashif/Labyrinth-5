// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BacktrackerCell.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class that creates a cell for the Backtracker algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents.Cells
{
    /// <summary>
    /// Internal class that creates a cell for the Backtracker algorithm.
    /// </summary>
    internal class BacktrackerCell : MazeCell
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="BacktrackerCell"/> class.
        /// </summary>
        /// <param name="row">Row position.</param>
        /// <param name="col">Col position.</param>
        internal BacktrackerCell(int row, int col)
            : base(row, col)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether a maze cell is a Backtracked.
        /// </summary>
        internal bool IsBacktracked { get; set; }
    }
}
