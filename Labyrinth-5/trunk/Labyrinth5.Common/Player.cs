namespace Labyrinth5.Common
{
    using System;

    public class Player
    {
        //TODO: Code repetition! remove/refactor
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
            this.row = startRow;
            this.column = startCol;
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

        //TODO: following smelly code - remove/refactor

        public void Move(int dirX, int dirY)
        {

            //if (!labyrinth.IsCellAvailable(this.row + dirX, this.column + dirY))
            //{
            //    return;
            //}

            //if (!labyrinth.IsCellAvailable(column + dirY, row + dirX))
            //{
            //    Console.WriteLine("Invalid Move!");
            //    Console.WriteLine("**Press a key to continue**");
            //    Console.ReadKey();
            //    return;
            //}
            //else
            //{
            //    labyrinth.MarkCellAsAvailable(this.column, this.row);
            //    labyrinth.MarkCellAsOccupied(this.column + dirY, this.row + dirX);
            //    this.column += dirY;
            //    this.row += dirX;
            //    return;
            //}
        }
    }
}
