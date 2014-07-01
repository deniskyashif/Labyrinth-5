namespace Labyrinth5.Common
{
    internal struct MatrixCoordinates
    {
        public MatrixCoordinates(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

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
    }
}
