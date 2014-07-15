namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;

    internal class ConsoleRenderer : IRenderer
    {
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

        public void RenderMany(IEnumerable<IRenderable> collection)
        {
            foreach (var item in collection)
            {
                this.Render(item);
            }
        }

        public void RenderText(string text, int leftOffset, int topOffset)
        {
            Console.SetCursorPosition(leftOffset, topOffset);
            Console.Write(text);
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