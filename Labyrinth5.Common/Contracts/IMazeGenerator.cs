namespace Labyrinth5.Common.Contracts
{
    public interface IMazeGenerator
    {
        IMazeCell[,] Generate(int rows, int columns);
    }
}
