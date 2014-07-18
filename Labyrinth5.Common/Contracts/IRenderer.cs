// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an IRenderer interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
    using System.Collections.Generic;

<<<<<<< HEAD
    internal interface IRenderer
=======
    /// <summary>
    /// Defines an IRenderer interface.
    /// </summary>
    public interface IRenderer
>>>>>>> 9cb912cd66b1a44b4cfde2bec4adc5a9d1c36a4e
    {
        /// <summary>
        /// Renders renderable object.
        /// </summary>
        /// <param name="obj">Renderable object.</param>
        void Render(IRenderable obj);

        /// <summary>
        /// Renders a collection of renderable objects.
        /// </summary>
        /// <param name="collection">Collection of renderable objects.</param>
        void RenderMany(IEnumerable<IRenderable> collection);

        /// <summary>
        /// Renders Text.
        /// </summary>
        /// <param name="text">Text string to be rendered.</param>
        /// <param name="leftOffset">Assigns left coordinate of initial render point.</param>
        /// <param name="topOffset">Assigns top coordinate of initial render point.</param>
        void RenderText(string text, int leftOffset, int topOffset);

        /// <summary>
        /// Clears rendered object.
        /// </summary>
        /// <param name="obj">Renderable object.</param>
        void Clear(IRenderable obj);

        /// <summary>
        /// Clears all rendered objects.
        /// </summary>
        void ClearAll();
    }
}
