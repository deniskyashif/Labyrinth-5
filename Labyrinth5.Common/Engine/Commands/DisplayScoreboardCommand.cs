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
        private List<string> scoreboardList;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayScoreboardCommand"/> class.
        /// </summary>
        /// <param name="renderer">Renderer instance.</param>
        /// <param name="newScores">List of scores.</param>
        public DisplayScoreboardCommand(IRenderer renderer, List<string> newScores)
        {
            this.renderer = renderer;
            this.GetNewScoreboard(newScores);
        }

        /// <summary>
        /// Copies a list of scores from input to the private field scoreboardList.
        /// </summary>
        /// <param name="newScores">List of scores.</param>
        public void GetNewScoreboard(List<string> newScores)
        {
            this.scoreboardList = new List<string>();

            foreach (var line in newScores)
            {
                this.scoreboardList.Add(line);
            }

            this.scoreboardList.Add(ReturnMessage);
        }

        /// <summary>
        /// Executes the Rendering of the Scoreboard.
        /// </summary>
        public void Execute()
        {
            int row = TopOffset;

            foreach (var line in this.scoreboardList)
            {
                this.renderer.RenderText(line, LeftOffset, row);
                row++;
            }
        }
    }
}
