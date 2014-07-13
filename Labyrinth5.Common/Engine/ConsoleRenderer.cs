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
        private readonly int mazeRows;
        private readonly int mazeCols;
        private int prevPlayerRow = 1;
        private int prevPlayerCol = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mazeRows">Used in text rendering</param>
        /// <param name="mazeCols">Used in text rendering</param>
        public ConsoleRenderer(int mazeRows, int mazeCols)
        {
            this.mazeRows = mazeRows;
            this.mazeCols = mazeCols;
        }

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
            DeleteAtPosition(prevPlayerCol, prevPlayerRow);
            prevPlayerRow = player.Row;
            prevPlayerCol = player.Col;
            WriteOnPosition(player.Col, player.Row, player.Symbol, ConsoleColor.Red);
        }

        /// <summary>
        /// Prints text on the next free line under the maze
        /// </summary>
        /// <param name="text">String array. Prints every element on new line</param>
        public void RenderText(params string[] text)
        {
            ClearText();
            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(0, mazeRows + 1 + i);
                Console.Write(text[i]);
            }
        }

        public void ClearText()
        {
            for (int i = 1; i < 5; i++)
            {
                Console.SetCursorPosition(0, mazeRows + i);
                Console.Write(new string(' ', Console.BufferWidth - Console.CursorLeft));
            }
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