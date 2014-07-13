namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Contracts;

    public class Player : IPlayer 
    {
        private const char symbol = '@';
        private const int PlayerStartRow = 1;
        private const int PlayerStartCol = 1;

        private int row;
        private int col;
        private int score;

        public Player() : this(PlayerStartRow, PlayerStartCol)
        {
        }

        public Player(int startRow, int startCol)
        {
            this.Row = startRow;
            this.Col = startCol;
            this.score = 0;
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value > 0)
                {
                    this.score = value;
                }
                else
                {
                    throw new ArgumentException("Score or value can't be negative");
                }
            }
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
                return this.col; 
            }

            private set 
            { 
                this.col = value; 
            }
        }
        public void Restart()
        {
            this.row = PlayerStartRow;
            this.col = PlayerStartCol;
            this.score = 0;
        }
        public void Move(int rows, int cols)
        {
            this.Row += rows;
            this.Col += cols;
        }
    }
}