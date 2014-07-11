namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;
    using System;

    public class ConsoleEngine : IEngine
    {
        private IMazeGenerator generator;
        private Maze maze;
        private ConsoleRenderer renderer;
        public ConsoleEngine()
        {
            generator = new BacktrackerMazeGenerator();
            maze = new Maze(generator);
            renderer = new ConsoleRenderer();
        }
        
        public void Run()
        {
            maze.Generate(20, 20);
            renderer.Render(maze);
        }
    }
}
