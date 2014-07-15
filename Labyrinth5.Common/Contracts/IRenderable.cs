namespace Labyrinth5.Common.Contracts
{
    public interface IRenderable
    {
        MatrixCoordinates TopLeftPosition { get; set; }

        char[,] GetImage();
    }
}
