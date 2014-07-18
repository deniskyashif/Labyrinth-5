// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatrixCoordinates.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Struct that holds coordinates for the maze matrix.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common
{
    /// <summary>
    /// Struct that holds coordinates for the maze matrix.
    /// </summary>
    public struct MatrixCoordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixCoordinates"/> struct.
        /// </summary>
        /// <param name="row">Row coordinate.</param>
        /// <param name="col">Col coordinate.</param>
        internal MatrixCoordinates(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets or sets Row coordinate.
        /// </summary>
        internal int Row { get; set; }

        /// <summary>
        /// Gets or sets Col coordinate.
        /// </summary>
        internal int Col { get; set; }

        /// <summary>
        /// Overrates + operator.
        /// </summary>
        /// <param name="a">First set of coordinates.</param>
        /// <param name="b">Second set of coordinates.</param>
        /// <returns>Sum of the two MatrixCoordinates.</returns>
        public static MatrixCoordinates operator +(MatrixCoordinates a, MatrixCoordinates b)
        {
            return new MatrixCoordinates(a.Row + b.Row, a.Col + b.Col);
        }

        /// <summary>
        /// Overrates - operator.
        /// </summary>
        /// <param name="a">First set of coordinates.</param>
        /// <param name="b">Second set of coordinates.</param>
        /// <returns>Difference of the two MatrixCoordinates.</returns>
        public static MatrixCoordinates operator -(MatrixCoordinates a, MatrixCoordinates b)
        {
            return new MatrixCoordinates(a.Row - b.Row, a.Col - b.Col);
        }

        /// <summary>
        /// Overrides Equals method.
        /// Validates if input is instance of MatrixCoordinates. 
        /// </summary>
        /// <param name="obj">An Object for comparison.</param>
        /// <returns>Indicates weather two objects are equal.</returns>
        public override bool Equals(object obj)
        {
            var objAsMatrixCoordinates = (MatrixCoordinates)obj;

            return objAsMatrixCoordinates.Row == this.Row 
                && objAsMatrixCoordinates.Col == this.Col;
        }

        /// <summary>
        /// Overrides GetHashCode.
        /// </summary>
        /// <returns>MatrixCoordinates HashCode.</returns>
        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^ this.Col.GetHashCode();
        }

        /// <summary>
        /// Overrides ToString.
        /// </summary>
        /// <returns>Coordinates to string.</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Row, this.Col);
        }
    }
}
