// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMazeCell.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an IMazeCell interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
    /// <summary>
    /// Defines an IMazeCell interface.
    /// </summary>
    internal interface IMazeCell
    {
        /// <summary>
        /// Gets maze cell position.
        /// </summary>
        /// <value>The position of a game element.</value>
        MatrixCoordinates Position { get; }

        /// <summary>
        /// Gets or sets a value indicating whether a maze cell is a wall.
        /// </summary>
        /// <value>The maze cell is it wall state.</value>
        bool IsWall { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a maze cell is an exit.
        /// </summary>
        /// <value>Is the cell exit.</value>
        bool IsExit { get; set; }
    }
}
