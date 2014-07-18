namespace Labyrinth5.Common.Engine
{
    using System;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Game engine. Entry point of the app.
    /// </summary>
    public class ConsoleEngine : IEngine
    {
        private static readonly ConsoleEngine engineInstance = new ConsoleEngine();

        private readonly ICommandInterpreter interpreter;

        private ConsoleEngine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public static ConsoleEngine Instance
        {
            get
            {
                return engineInstance;
            }
        }

        /// <summary>
        /// Game loop. Runs until player reaches exit
        /// </summary>
        public void Run()
        {
            var command = "info";

            while (true)
            {
                this.interpreter.ParseAndDispatch(command);
                command = Console.ReadLine();
            }
        }
    }
}