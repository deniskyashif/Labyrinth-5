namespace Labyrinth5.Common.Contracts
{
    public interface IMazeCell
    {
        int Row { get; }

        int Col { get; }

        bool IsWall { get; set; }
    }
}
