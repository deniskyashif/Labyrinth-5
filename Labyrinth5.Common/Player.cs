namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Contracts;

    internal class Player: IRenderable 
    {
        private const int InitialPositionTop = 1;
        private const int InitialPositionLeft = 1;
        private const char PlayerImage = '☺';
        
        private MatrixCoordinates topLeftPosition;
        private MatrixCoordinates direction;

        public Player() 
            : this(InitialPositionTop, InitialPositionLeft)
        { 
        }

        public Player(int leftCoordinate, int topCoordinate)
        {
            this.TopLeftPosition = new MatrixCoordinates(topCoordinate, leftCoordinate);
        }

        public MatrixCoordinates Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        public MatrixCoordinates TopLeftPosition
        {
            get { return this.topLeftPosition; }
            set { this.topLeftPosition = value; }
        }

        public void Move()
        {
            this.TopLeftPosition += this.Direction;
        }

        public char[,] GetImage()
        {
            return new char[,] { { PlayerImage } };
        }
    }
}