namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Contracts;

    public class Player:IRenderable 
    {
        private const int PlayerStartRow = 0;
        private const int PlayerStartCol = 0;

        private int row;
        private int column;

        public Player()
            : this(PlayerStartRow, PlayerStartCol)
        {
        }

        public Player(int startRow, int startCol)
        {
            this.Row = startRow;
            this.Column = startCol;
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

        public int Column 
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

        public void Move(int dirX, int dirY)
        {
            this.Row += dirX;
            this.Column += dirY;
        }

        //TODO
        public MatrixCoordinates TopLeftPosition
        {
            get { throw new NotImplementedException(); }
        }

        public char[,] GetImage()
        {
            throw new NotImplementedException();
        }
    }
}
