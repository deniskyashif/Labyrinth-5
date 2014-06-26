namespace Labyrinth5.Common.Mazes
{
    internal interface IMazeGenerator
    {
        MazeCell[,] Generate(int rows, int columns);
    }
}
