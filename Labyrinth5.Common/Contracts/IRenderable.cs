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
<<<<<<< HEAD
    internal interface IRenderable
=======
    /// <summary>
    /// Defines an IRenderable interface. 
    /// </summary>
    public interface IRenderable
>>>>>>> 9cb912cd66b1a44b4cfde2bec4adc5a9d1c36a4e
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
