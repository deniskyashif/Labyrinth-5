namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Contracts;

    public class Player:IPlayer 
    {
        private const int PlayerStartRow = 1;
        private const int PlayerStartCol = 1;
        private const char symbol = '@';

        private int row;
        private int column;

        public Player()
            : this(PlayerStartRow, PlayerStartCol)
        {
        }

        public Player(int startRow, int startCol)
        {
            this.Row = startRow;
            this.Col = startCol;
        }

        public char Symbol
        {
            get
            {
                return symbol;
            }
        }

        public int Row 
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

        public int Col 
        {
            get 
            { 
                return this.column; 
            }

            private set 
            { 
                this.column = value; 
            } 
        }

        public void Move(int rows, int cols)
        {
            this.Row += rows;
            this.Col += cols;
        }

    }
}
