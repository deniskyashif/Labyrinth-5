namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common;
    
    internal class ConsoleRenderer : IRenderer
    {
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

        public void RenderPlayer(Player player)
        {
            WriteOnPosition(player.Col, player.Row, player.Symbol, ConsoleColor.Red);
        }

        public void RenderText(string text)
        {          
            //TODO Fix magic numbers 21 - current maze size(20) + 1
            Console.SetCursorPosition(0, 21);
            Console.Write(text);
        }

        public void RenderMany(IEnumerable<IRenderable> collection)
        {
            foreach (var item in collection)
            {
                this.Render(item);
            }
        }

        private void WriteOnPosition(int row, int col, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(row, col);
            Console.Write(symbol);
        }
        private void DeleteAtPosition(int row, int col)
        {
            WriteOnPosition(row, col, '\u2588', ConsoleColor.Black);
        }

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

        public void ClearAll()
        {
            Console.Clear();
        }
    }
}
