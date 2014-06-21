namespace Labyrinth5.Common
{
    using System;

    internal struct MazeCell
    {
        private const char WallSymbol = '\u2593';
        private const char PathSymbol = '\u00a0';
        private const char EntranceSymbol = '⌂';
        private const char ExitSymbol = 'E';

        private int row;
        private int col;
        private CellType type;
        private bool isVisited;
        
        internal MazeCell(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
            this.Type = CellType.Wall;
            this.IsVisited = false;
        }

        internal int Row
        {
            get 
            {
                return this.row;
            } 

            private set 
            { 
                this.row = value; 
            } 
        }

        internal int Col
        {
            get
            {
                return this.col;
            }

            private set
            {
                this.col = value;
            }
        }

        internal CellType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        internal bool IsVisited
        {
            get
            {
                return this.isVisited;
            }

            set
            {
                this.isVisited = value;
            }
        }

        public override string ToString()
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
                    return string.Empty;
            }
        }
    }
}
