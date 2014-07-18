namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;
using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;

    class SetBacktrackerCommand : ICommand
    {
        private Maze maze;

        public SetBacktrackerCommand(Maze maze)
        {
            this.maze = maze;
        }

        public void Execute()
        {
            this.maze.GenerationStrategy = new BacktrackerMazeGenerator();
        }
    }
}
