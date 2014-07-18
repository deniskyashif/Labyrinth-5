namespace Labyrinth5.Common.Engine.Commands
{
    using System.Collections.Generic;
    using Labyrinth5.Common.Contracts;

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
            GetNewScoreboard(newScores);
        }

        public void GetNewScoreboard(List<string> newScores)
        {
            scoreboardList = new List<string>();
            foreach (var line in newScores)
            {
                scoreboardList.Add(line);
            }
            scoreboardList.Add(ReturnMessage);
        }

        public void Execute()
        {
            this.renderer.ClearAll();

            int row = TopOffset;

            foreach (var line in scoreboardList)
            {
                this.renderer.RenderText(line, LeftOffset, row);
                row++;
            }
        }
    }
}
