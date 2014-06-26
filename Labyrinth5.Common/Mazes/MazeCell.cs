namespace Labyrinth5.Common.Mazes
{
    using System;

    internal class MazeCell 
    {
        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';
        private const char EntranceSymbol = '#';
        private const char ExitSymbol = 'E';

        protected internal MazeCell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Type = CellType.Wall;
        }

        internal int Row { get; private set; }
        internal int Col { get; private set; }
        internal CellType Type { get; set; }
        internal bool IsBacktracked { get; set; }
        
        public string GetSymbol()
        {
            switch (this.Type)
            {
                case CellType.Wall:
                    return WallSymbol.ToString();
                case CellType.Path:
                    return PathSymbol.ToString();
                case CellType.Entrance:
                    return EntranceSymbol.ToString();
                case CellType.Exit:
                    return ExitSymbol.ToString();
                default:
                    throw new InvalidOperationException("There should be no typeless cells!");
            }
        }
    }
}
