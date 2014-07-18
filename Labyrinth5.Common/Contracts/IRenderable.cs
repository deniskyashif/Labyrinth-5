namespace Labyrinth5.Common.Contracts
{
    internal interface IRenderable
    {
        MatrixCoordinates TopLeftPosition { get; set; }

        char[,] GetImage();
    }
}
