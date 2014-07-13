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

        public override bool Equals(object obj)
        {
            var objAsMatrixCoordinates = (MatrixCoordinates)obj;

            return objAsMatrixCoordinates.Row == this.Row 
                && objAsMatrixCoordinates.Col == this.Col;
        }
    }
}
