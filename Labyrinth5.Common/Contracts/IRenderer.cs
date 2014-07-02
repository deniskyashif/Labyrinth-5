namespace Labyrinth5.Common.Contracts
{
    internal interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void Render(IRenderable obj);

        void RenderAll();

        void Clear(IRenderable obj);

        void ClearAll();
    }
}
