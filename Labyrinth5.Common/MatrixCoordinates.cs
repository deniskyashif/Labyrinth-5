namespace Labyrinth5.Common
{
    public struct MatrixCoordinates
    {
        internal MatrixCoordinates(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        internal int Row { get; set; }
        internal int Col { get; set; }

        public static MatrixCoordinates operator +(MatrixCoordinates a, MatrixCoordinates b)
        {
            return new MatrixCoordinates(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixCoordinates operator -(MatrixCoordinates a, MatrixCoordinates b)
        {
            return new MatrixCoordinates(a.Row - b.Row, a.Col - b.Col);
        }

        public override bool Equals(object obj)
        {
            var objAsMatrixCoordinates = (MatrixCoordinates)obj;

            return objAsMatrixCoordinates.Row == this.Row 
                && objAsMatrixCoordinates.Col == this.Col;
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^ this.Col.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Row, this.Col);
        }
    }
}
