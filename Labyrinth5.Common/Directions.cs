namespace Labyrinth5.Common
{
    internal static class Directions
    {
        internal static readonly MatrixCoordinates Up =
            new MatrixCoordinates(-1, 0);

        internal static readonly MatrixCoordinates Right =
            new MatrixCoordinates(0, 1);

        internal static readonly MatrixCoordinates Down =
            new MatrixCoordinates(1, 0);

        internal static readonly MatrixCoordinates Left =
            new MatrixCoordinates(0, -1);
    }
}
