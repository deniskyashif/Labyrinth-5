namespace Labyrinth5.Common
{
    using System;

    internal class MazeCell     //TODO: Add data validation
    {
        private int row;
        private int col;
        private bool isVisited;
        private bool isWall;

        internal MazeCell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.IsWall = true;
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

        internal bool IsWall
        {
            get
            {
                return this.isWall;
            }
            set
            {
                this.isWall = value;
            }
        }
    }
}
