﻿namespace Labyrinth5.Common.MazeComponents.Cells
{
    internal class BacktrackerCell : MazeCell
    {
        internal BacktrackerCell(int row, int col)
            : base(row, col)
        {
        }

        internal bool IsBacktracked { get; set; }
    }
}
