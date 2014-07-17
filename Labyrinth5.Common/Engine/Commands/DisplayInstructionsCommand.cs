// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayInstructionsCommand.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Internal class Handling the call to render of the game info. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Internal class Handling the call to render of the game info. 
    /// </summary>
    internal class DisplayInstructionsCommand : ICommand
    {
        /// <summary>
        /// Game Info Render position top coordinate.
        /// </summary>
        private const int TopOffset = 1;

        /// <summary>
        /// Game Info Render position left coordinate.
        /// </summary>
        private const int LeftOffset = 0;

        /// <summary>
        /// Game Instructions text.
        /// </summary>
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

        /// <summary>
        /// Renderer class instance for executing the rendering of the info.
        /// </summary>
        private IRenderer renderer;

        /// <summary>
        /// Constructor. Initiates the renderer.
        /// </summary>
        /// <param name="renderer">Renderer class instance.</param>
        public DisplayInstructionsCommand(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        /// <summary>
        /// Implementation of the ICommand interface.
        /// Executes the rendering of the game info.
        /// </summary>
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
