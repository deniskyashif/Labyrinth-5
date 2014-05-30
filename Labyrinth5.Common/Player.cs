namespace Labyrinth5.Common
{
    using System;

    public class Player
    {
        private const int PlayerStartRow = 3;
        private const int PlayerStartCol = 3;

        private int row;
        private int column;

        public Player()
        {
            this.row = PlayerStartRow;
            this.column = PlayerStartCol;
        }

        public int Row 
        { 
            get 
            { 
                return this.row; 
            }
 
            private set 
            { 
                this.column = value; 
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

        //TODO: following bulk code - remove/refactor

        public void Move(int dirX, int dirY, Maze labyrinth)
        {

            if (this.IsMoveValid(this.row + dirX, this.column + dirY, labyrinth) == false)
            {
                return;
            }

            if (!labyrinth.IsCellAvailable(column + dirY, row + dirX))
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                return;
            }
            else
            {
                labyrinth.MarkCellAsAvailable(this.column, this.row);
                labyrinth.MarkCellAsOccupied(this.column + dirY, this.row + dirX);
                this.column += dirY;
                this.row += dirX;
                return;
            }
        }

        private bool IsMoveValid(int x, int y, Maze labyrinth)
        {
            if (x < 0 || x > labyrinth.Rows - 1 || y < 0 || y > labyrinth.Columns - 1)
            {
                return false;
            }

            return true;
        }
    }
}
