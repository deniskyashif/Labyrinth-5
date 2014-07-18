namespace Labyrinth5.Common.Contracts
{
    internal interface IMazeCell
    {
        MatrixCoordinates Position { get; }

        bool IsWall { get; set; }

        bool IsExit { get; set; }
    }
}
