// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrimCell.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class that creates a cell for the PrimCell algorithm.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.MazeComponents.Cells
{
    /// <summary>
    /// Internal class that creates a cell for the PrimCell algorithm.
    /// </summary>
    internal class PrimCell : MazeCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimCell"/> class.
        /// Constructor inherited from MazeCell class.
        /// </summary>
        /// <param name="row">Row position.</param>
        /// <param name="col">Col position.</param>
        internal PrimCell(int row, int col)
            : base(row, col)
        {
        }
    }
}
