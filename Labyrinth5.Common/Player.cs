namespace Labyrinth5.Common
{
    using System;

    public class Player
    {
        private const int playerStartRow = 3;
        private const int playerStartCol = 3;

        public int playerPositionX;
        public int playerPositionY;
        
        public Player()
        {
            this.playerPositionX = playerStartRow;
            this.playerPositionY = playerStartCol;
        }

        public void Move(int dirX, int dirY, Maze labyrinth)
        {

            if (this.IsMoveValid(this.playerPositionX + dirX, this.playerPositionY + dirY ,labyrinth) == false)
            {
                return;
            }

            if (labyrinth.matrix[playerPositionY + dirY, playerPositionX + dirX] == 'X')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                return;
            }
            else
            {
                labyrinth.matrix[this.playerPositionY, this.playerPositionX] = '-';
                labyrinth.matrix[this.playerPositionY + dirY, this.playerPositionX + dirX] = '*';
                this.playerPositionY += dirY;
                this.playerPositionX += dirX;
                return;
            }
        }

        private bool IsMoveValid(int x, int y, Maze labyrinth)
        {
            if (x < 0 || x > labyrinth.matrix.GetLength(0) - 1 || y < 0 || y > labyrinth.matrix.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }
}
