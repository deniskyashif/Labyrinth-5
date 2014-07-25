// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayScoreboardCommand.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Internal class Handling the call to render of the scoreboard. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Engine.Commands
{
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    ///   Internal class Handling the call to render of the scoreboard.
    /// </summary>
    internal class DisplayScoreboardCommand : ICommand
    {
        /// <summary>
        /// Top coordinate of the render starting position.
        /// </summary>
        private const int TopOffset = 1;

        /// <summary>
        /// Left coordinate of the render starting position.
        /// </summary>
        private const int LeftOffset = 0;

        /// <summary>
        /// Return Message.
        /// </summary>
        private const string ReturnMessage = "Press Any Key to Return";

        /// <summary>
        /// Renderer instance.
        /// </summary>
        private IRenderer renderer;

        /// <summary>
        /// List of scores.
        /// </summary>
        private ScoreboardManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayScoreboardCommand"/> class.
        /// </summary>
        /// <param name="renderer">Renderer instance.</param>
        /// <param name="manager">ScoreboardManager instance.</param>
        public DisplayScoreboardCommand(IRenderer renderer, ScoreboardManager manager)
        {
            this.renderer = renderer;
            this.manager = manager;
        }

        /// <summary>
        /// Executes the Rendering of the Scoreboard.
        /// </summary>
        public void Execute()
        {
            this.renderer.ClearAll();

            int row = TopOffset;
            var scoresList = this.manager.GetScoresList();

            foreach (var line in scoresList)
            {
                this.renderer.RenderText(line, LeftOffset, row);
                row++;
            }
        }
    }
}
