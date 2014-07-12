namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common;
    
    /// <summary>
    /// Used for printing anything on the console
    /// </summary>
    internal class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Moves cursor at position and displays single char.
        /// Works differently from SetCursorPosition. Top left corner of the console is (0, 0).
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="symbol"></param>
        /// <param name="color"></param>
        private void WriteOnPosition(int row, int col, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(row, col);
            Console.Write(symbol);
        }

        /// <summary>
        /// Uses WriteOnPosition, prints a black square over position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void DeleteAtPosition(int row, int col)
        {
            WriteOnPosition(row, col, '\u2588', ConsoleColor.Black);
        }

        /// <summary>
        /// Prints a two dismensional char array at coordinates (0, 0) 
        /// </summary>
        /// <param name="obj">IRenderable object, GetImage() should return two dimensional char array</param>
        public void Render(IRenderable obj)
        {
            var objectImage = obj.GetImage();

            for (int row = 0; row < objectImage.GetLength(0); row++)
            { 
                for (int col = 0; col < objectImage.GetLength(1); col++)
                {
                    char currentSymbol = objectImage[row, col];
                    WriteOnPosition(col, row, currentSymbol, ConsoleColor.Green);
                }
            }
        }

        /// <summary>
        /// Prints the player char at current player coordinates
        /// </summary>
        /// <param name="player"></param>
        public void RenderPlayer(Player player)
        {
            WriteOnPosition(player.Col, player.Row, player.Symbol, ConsoleColor.Red);
        }

        /// <summary>
        /// Prints text on the next free line under the maze
        /// </summary>
        /// <param name="text"></param>
        public void RenderText(string text)
        { 
            //TODO Fix magic numbers 21 - current maze size(20) + 1
            Console.SetCursorPosition(0, 21);
            Console.Write(text);
        }

        /// <summary>
        /// Renders many IRenderable objects. Not used currently.
        /// </summary>
        /// <param name="collection"></param>
        public void RenderMany(IEnumerable<IRenderable> collection)
        {
            foreach (var item in collection)
            {
                this.Render(item);
            }
        }
        
        /// <summary>
        /// Uses DeleteAtPostion() to clear IRenderable object. Not used currently.
        /// </summary>
        /// <param name="obj"></param>
        public void Clear(IRenderable obj)
        {
            var objectImage = obj.GetImage();

            for (int row = 0; row < objectImage.GetLength(0); row++)
            {
                for (int col = 0; col < objectImage.GetLength(1); col++)
                {
                    DeleteAtPosition(row, col);
                }
            }
        }

        /// <summary>
        /// Clears the console. Duh.
        /// </summary>
        public void ClearAll()
        {
            Console.Clear();
        }
    }
}