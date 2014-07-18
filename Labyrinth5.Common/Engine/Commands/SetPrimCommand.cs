namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;

    class SetPrimCommand : ICommand
    {
        private Maze maze;

        public SetPrimCommand(Maze maze)
        {
            this.maze = maze;
        }

        public void Execute()
        {
            this.maze.GenerationStrategy = new PrimMazeGenerator();
        }
    }
}
