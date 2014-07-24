namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;

    internal class SetBacktrackerCommand : ICommand
    {
        /// <summary>
        /// Private instance of the Maze class.
        /// </summary>
        private Maze maze;

        /// <summary>
        /// Constructor method. Assigns the the field of type Maze to an instance of Maze.
        /// </summary>
        /// <param name="maze">Instance of Maze.</param>
        public SetBacktrackerCommand(Maze maze)
        {
            this.maze = maze;
        }

        /// <summary>
        /// Sets maze's generation strategy(algorithm) to Backtracker.
        /// </summary>
        public void Execute()
        {
            this.maze.GenerationStrategy = new BacktrackerMazeGenerator();
        }
    }
}
