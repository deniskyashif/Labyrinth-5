// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderable.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an IRenderable interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
    /// <summary>
    /// Defines an IRenderable interface. 
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Gets or sets position for rendering.
        /// </summary>
        /// <value>Top left position.</value>
        MatrixCoordinates TopLeftPosition { get; set; }

        /// <summary>
        /// Char representation of the renderable object.
        /// </summary>
        /// <returns>Char matrix.</returns>
        char[,] GetImage();
    }
}
