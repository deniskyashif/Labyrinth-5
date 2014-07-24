// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleEngine.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Game engine. Entry point of the app.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Engine
{
    using System;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Game engine. Entry point of the app.
    /// </summary>
    public class ConsoleEngine : IEngine
    {
        /// <summary>
        /// The single instance of the ConsoleEngine class.
        /// </summary>
        private static readonly ConsoleEngine engineInstance = new ConsoleEngine();

        /// <summary>
        /// Internal instance of the ConsoleEngine.
        /// </summary>
        private static readonly ConsoleEngine instance = new ConsoleEngine();

        /// <summary>
        /// CommandInterpreter instance.
        /// </summary>
        private readonly ICommandInterpreter interpreter;

        /// <summary>
        ///  Prevents a default instance of the <see cref="ConsoleEngine"/> class from being created.
        /// </summary>
        private ConsoleEngine()
        {
            this.interpreter = new CommandInterpreter();
        }

        /// <summary>
        /// Gets an instance of ConsoleEngine.
        /// </summary>
        /// <value>Console Engine.</value>
        public static ConsoleEngine Instance
        {
            get
            {
                return engineInstance;
            }
        }

        /// <summary>
        /// Game loop. Runs until player reaches exit.
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