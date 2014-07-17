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
        /// Constructor inherited from MazeCell class.
        /// </summary>
        /// <param name="row">Row position.</param>
        /// <param name="col">Col position.</param>
        internal BacktrackerCell(int row, int col)
            : base(row, col)
        {
        }

        /// <summary>
        /// Holds information on the Backtracked status of the cell.
        /// </summary>
        internal bool IsBacktracked { get; set; }
    }
}
