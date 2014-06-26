namespace Labyrinth5.Common.Mazes
{
    internal class MazeContext
    {
        private IMazeGenerator strategy;

        internal MazeContext(IMazeGenerator generator)
        {
            this.strategy = generator;
        }

        internal MazeCell[,] Generate(int rows, int columns)
        {
            return this.strategy.Generate(rows, columns);
        }
    }
}
