namespace Labyrinth5.Common.Contracts
{
    internal interface IMazeGenerator
    {
        IMazeCell[,] Generate(int rows, int columns);
    }
}
