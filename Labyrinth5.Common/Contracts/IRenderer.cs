namespace Labyrinth5.Common.Contracts
{
    using System.Collections.Generic;

    internal interface IRenderer
    {
        void Render(IRenderable obj);

        void RenderMany(IEnumerable<IRenderable> collection);

        void RenderText(string text, int leftOffset, int topOffset);

        void Clear(IRenderable obj);

        void ClearAll();
    }
}
