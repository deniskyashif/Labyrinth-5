namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;

    internal class DisplayInstructionsCommand : ICommand
    {
        private const int TopOffset = 1;
        private const int LeftOffset = 0;

        private readonly string[] gameInstructions = new string[]
        {
            new string('-', 25),
            "Game Instructions: ",
            new string('-', 25),
            " - Type <init> and hit <ENTER> to begin a new game.",
            "   - optionally type two integers between 10 and 60 to set custom maze size",
            " - Type <info> and hit <ENTER> to view game instructions.",
            " - Type <move> or <m> followed by: ",
            "   - <up> or <w> to move player up",
            "   - <right> or <d> to move player right",
            "   - <down> or <s> to move player down",
            "   - <left> or <l> to move player left",
            " - Type <set> to switch maze generation algorithm followed by:",
            "   - <backtracker> - for Iterative Backtracker algorithm.",
            "   - <prim> - for Prim's algorithm.",
            " - Type <score> to get the scoreboard.", 
            " - Type <exit> to end game." 
        };

        private IRenderer renderer;

        public DisplayInstructionsCommand(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Execute()
        {
            this.renderer.ClearAll();

            int row = TopOffset;

            foreach (var line in this.gameInstructions)
            {
                this.renderer.RenderText(line, LeftOffset, row);
                row++;
            }
        }
    }
}
