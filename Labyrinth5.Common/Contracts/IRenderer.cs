namespace Labyrinth5.Common.Contracts
{
    using System.Collections.Generic;

    internal interface IRenderer
    {
        void Render(IRenderable obj);

        void RenderMany(IEnumerable<IRenderable> collection);

        void Clear(IRenderable obj);

        void ClearAll();
    }
}
