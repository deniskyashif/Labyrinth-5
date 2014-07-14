namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.Contracts;
    using System;

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