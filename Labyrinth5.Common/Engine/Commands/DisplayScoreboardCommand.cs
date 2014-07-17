// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Internal class handeling the call to render of the scoreboard. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Engine.Commands
{
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    ///   Internal class handeling the call to render of the scoreboard.
    /// </summary>
    internal class DisplayScoreboardCommand : ICommand
    {
        private const int TopOffset = 1;
        private const int LeftOffset = 0;
        private const string ReturnMessage = "Press Any Key to Return";
        private IRenderer renderer;
        private List<string> scoreboardList;

        public DisplayScoreboardCommand(IRenderer renderer, List<string> newScores)
        {
            this.renderer = renderer;
            this.GetNewScoreboard(newScores);
        }

        public void GetNewScoreboard(List<string> newScores)
        {
            this.scoreboardList = new List<string>();

            foreach (var line in newScores)
            {
                this.scoreboardList.Add(line);
            }

            this.scoreboardList.Add(ReturnMessage);
        }

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
