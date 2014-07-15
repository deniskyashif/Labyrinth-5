namespace Labyrinth5.Common.MazeComponents.Cells
{
    using System;
    using Labyrinth5.Common.Contracts;

    internal abstract class MazeCell : IMazeCell
    {
        private MatrixCoordinates position; 

        protected internal MazeCell(int row, int col)
        {
            this.Position = new MatrixCoordinates(row, col);
            this.IsWall = true;
        }

        public MatrixCoordinates Position 
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value.Row < 0 || value.Col < 0)
                {
                    throw new ArgumentOutOfRangeException("Maze cells' position can't consist of negative corrdinates.");
                }

                this.position = value;
            }
        }

        public bool IsWall { get; set; }

        public bool IsExit { get; set; }
    }
}
