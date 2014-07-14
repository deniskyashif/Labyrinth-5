namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using System;

    /// <summary>
    /// Game engine. Entry point of the app.
    /// </summary>
    public class ConsoleEngine : IEngine
    {
        private static readonly ConsoleEngine instance = new ConsoleEngine();

        private readonly ICommandInterpreter interpreter;

        private ConsoleEngine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public static ConsoleEngine Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Game loop. Runs until player reaches exit
        /// </summary>
        public void Run()
        {
            string command = "init";

            while (true)
            {
                this.interpreter.ParseAndDispatch(command);
                command = Console.ReadLine();
            }
        }
    }
}