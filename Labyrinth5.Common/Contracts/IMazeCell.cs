namespace Labyrinth5.Common.Contracts
{
    public interface IMazeCell
    {
        MatrixCoordinates Position { get; }

        bool IsWall { get; set; }

        bool IsExit { get; set; }
    }
}
