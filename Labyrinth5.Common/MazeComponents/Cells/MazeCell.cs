namespace Labyrinth5.Common.MazeComponents.Cells
{
    using Labyrinth5.Common.Contracts;
    using System;

    public abstract class MazeCell : IMazeCell
    {
        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';
       
        protected internal MazeCell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.IsWall = true;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool IsWall { get; set; }
        
        public string GetImage()
        {
            return this.IsWall ? WallSymbol.ToString() : PathSymbol.ToString();
        }
    }
}
