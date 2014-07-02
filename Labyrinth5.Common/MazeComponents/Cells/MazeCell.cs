namespace Labyrinth5.Common.MazeComponents.Cells
{
    using Labyrinth5.Common.Contracts;
    using System;

    internal abstract class MazeCell : IMazeCell
    {
        protected internal MazeCell(int row, int col)
        {
            this.Position = new MatrixCoordinates(row, col);
            this.IsWall = true;
        }

        public MatrixCoordinates Position { get; set; }

        public bool IsWall { get; set; }
    }
}
