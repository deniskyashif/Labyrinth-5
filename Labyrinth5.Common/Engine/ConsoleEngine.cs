﻿namespace Labyrinth5.Common.Engine
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
        private Player player;
        private CommandInterpreter interpreter;

        public ConsoleEngine()
        {
            generator = new BacktrackerMazeGenerator();
            maze = new Maze(generator);
            renderer = new ConsoleRenderer();
            player = new Player();
            interpreter = new CommandInterpreter();
            Console.CursorVisible = false;
        }
        
        public void Run()
        {
            maze.Generate(20, 20);
            renderer.Render(maze);
            renderer.RenderPlayer(player);

            while (true)
            {
                string command = string.Empty;

                if (false)
                {
                    ///TODO game over message here
                }
                else
                {
                    renderer.RenderText("Enter your move (A=left, D-right, W=up, S=down):");
                    command = Console.ReadLine();
                }
                if (command == string.Empty)
                {
                    continue;
                }

                interpreter.ExecuteCommand(player, maze, command);
                renderer.RenderPlayer(player);
            }

        }
        
    }
}
