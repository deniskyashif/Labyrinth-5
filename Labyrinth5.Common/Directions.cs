namespace Labyrinth5.Common
{
    internal static class Directions
    {
        public static readonly MatrixCoordinates Up =
            new MatrixCoordinates(-1, 0);

        public static readonly MatrixCoordinates Right =
            new MatrixCoordinates(0, 1);

        public static readonly MatrixCoordinates Down =
            new MatrixCoordinates(1, 0);

        public static readonly MatrixCoordinates Left =
            new MatrixCoordinates(0, -1);
    }
}
