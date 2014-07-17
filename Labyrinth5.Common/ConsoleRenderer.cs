// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleRenderer.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
// Internel class Handling the Rendering of game content on the console.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Internal class Handling the Rendering of game content on the console.
    /// </summary>
    internal class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Renders a renderable object as a char at it's position.
        /// </summary>
        /// <param name="obj">Object to be rendered.</param>
        public void Render(IRenderable obj)
        {
            var objectImage = obj.GetImage();

            for (int row = 0; row < objectImage.GetLength(0); row++)
            {
                Console.SetCursorPosition(obj.TopLeftPosition.Col, obj.TopLeftPosition.Row + row);

                for (int col = 0; col < objectImage.GetLength(1); col++)
                {
                    Console.Write(objectImage[row, col]);
                }
            }
        }

        /// <summary>
        /// Renders a collection of Renderable objects.
        /// </summary>
        /// <param name="collection">Colection of objects to be rendered.</param>
        public void RenderMany(IEnumerable<IRenderable> collection)
        {
            foreach (var item in collection)
            {
                this.Render(item);
            }
        }

        /// <summary>
        /// Renders The text elements of the game.
        /// </summary>
        /// <param name="text">Text to be rendered.</param>
        /// <param name="leftOffset">Left coordinate of the text position.</param>
        /// <param name="topOffset">Top coordinate of the text position.</param>
        public void RenderText(string text, int leftOffset, int topOffset)
        {
            Console.SetCursorPosition(leftOffset, topOffset);
            Console.Write(text);
        }

        /// <summary>
        /// Clears a rendered object from the console.
        /// </summary>
        /// <param name="obj">object to be cleared.</param>
        public void Clear(IRenderable obj)
        {
            var objectImage = obj.GetImage();

            for (int row = 0; row < objectImage.GetLength(0); row++)
            {
                Console.SetCursorPosition(obj.TopLeftPosition.Col, obj.TopLeftPosition.Row + row);

                for (int col = 0; col < objectImage.GetLength(1); col++)
                {
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Clears all rendered content from the console.
        /// </summary>
        public void ClearAll()
        {
            Console.Clear();
        }
    }
}