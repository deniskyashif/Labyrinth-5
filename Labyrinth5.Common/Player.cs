// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class- process the game player. Holds player render information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common
{
    using System;
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Internal class- process the game player. Holds player render information.
    /// </summary>
    internal class Player : IRenderable 
    {
        /// <summary>
        /// Player Initial position top coordinate.
        /// </summary>
        private const int InitialPositionTop = 1;

        /// <summary>
        /// Player Initial position left coordinate.
        /// </summary>
        private const int InitialPositionLeft = 1;

        /// <summary>
        /// Player char representation.
        /// </summary>
        private const char PlayerImage = '☺';
        
        /// <summary>
        /// Player current render coordinates.
        /// </summary>
        private MatrixCoordinates topLeftPosition;

        /// <summary>
        /// Player move direction.
        /// </summary>
        private MatrixCoordinates direction;

        /// <summary>
        /// Default Constructor without input.
        /// </summary>
        public Player() 
            : this(InitialPositionTop, InitialPositionLeft)
        { 
        }

        /// <summary>
        /// Constructor. Sets a custom player positiom.
        /// </summary>
        /// <param name="leftCoordinate">Player left coordinate.</param>
        /// <param name="topCoordinate">Player top coordinate.</param>
        public Player(int leftCoordinate, int topCoordinate)
        {
            this.TopLeftPosition = new MatrixCoordinates(topCoordinate, leftCoordinate);
        }

        /// <summary>
        /// Gets move direction.
        /// Sets move direction.
        /// </summary>
        public MatrixCoordinates Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }

        /// <summary>
        /// Gets current position.
        /// Sets current position.
        /// </summary>
        public MatrixCoordinates TopLeftPosition
        {
            get { return this.topLeftPosition; }
            set { this.topLeftPosition = value; }
        }

        /// <summary>
        /// Changes the position of the player in accordance with the current direction.
        /// </summary>
        public void Move()
        {
            this.TopLeftPosition += this.Direction;
        }

        /// <summary>
        /// Implements IRenderable.
        /// </summary>
        /// <returns>Char representation of the player position.</returns>
        public char[,] GetImage()
        {
            return new char[,] { { PlayerImage } };
        }
    }
}