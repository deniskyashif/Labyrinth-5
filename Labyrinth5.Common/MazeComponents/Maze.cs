namespace Labyrinth5.Common.MazeComponents
{
    using Labyrinth5.Common.Contracts;

    public class Maze : IDrawable
    {
        private IMazeGenerator strategy;
        private IMazeCell[,] maze;

        public Maze(IMazeGenerator generator)
        {
            this.strategy = generator;
        }

        public int Rows
        {
            get { return this.maze.GetLength(0); }
        }

        public int Columns
        {
            get { return this.maze.GetLength(1); }
        }

        public IMazeCell this[int row, int col]
        {
            get { return this.maze[row, col]; }
        }

        public void SetStrategy(IMazeGenerator generator)
        {
            this.strategy = generator;
        }

        public void Generate(int rows, int columns) 
        {
            this.maze = this.strategy.Generate(rows, columns);
        }
    }
}
