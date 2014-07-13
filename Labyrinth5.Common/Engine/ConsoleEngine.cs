namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Generators;
    using System;

    //// <summary>
    /// App engine point. Initializes everything needed for it to run.
    /// Runs a while(true) loop until player is dead or game is restarted.
    /// </summary>
    public class ConsoleEngine : IEngine
    {
        private IMazeGenerator generator;
        private Maze maze;     
        private Player player;
        private ConsoleRenderer renderer;
        private CommandInterpreter interpreter;
        //private Scoreboard scoreboard;

        public ConsoleEngine()
        {
            Console.CursorVisible = false;
            Console.BufferWidth = 100;
            Console.WindowWidth = 100;
            Console.BufferHeight = 30;
            Console.WindowHeight = 30;
            
            generator = new BacktrackerMazeGenerator();
            maze = new Maze(generator, 10, 10);
            player = new Player();
            renderer = new ConsoleRenderer(maze.Rows, maze.Columns);      
            interpreter = new CommandInterpreter(renderer);
        }
        
        /// <summary>
        /// Prints starting maze and player. Starts the game loop.
        /// </summary>
        public void Run()
        {
            renderer.Render(maze);
            renderer.RenderPlayer(player);

            //reads user input until player has stepped on exit cell 
            while (true)
            {
                string command = string.Empty;
                
                if (maze[player.Row, player.Col].IsExit)
                {
                    renderer.RenderText("You win !", "**Press any key to exit**", "Moves: " + player.Score);
                    Console.ReadKey();
                    Environment.Exit(0);
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