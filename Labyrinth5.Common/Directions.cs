// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Directions.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class holding the information about the player move directions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common
{
    /// <summary>
    /// Internal class holding the information about the player move directions.
    /// </summary>
    internal static class Directions
    {
<<<<<<< HEAD
        internal static readonly MatrixCoordinates Up =
            new MatrixCoordinates(-1, 0);

        internal static readonly MatrixCoordinates Right =
            new MatrixCoordinates(0, 1);

        internal static readonly MatrixCoordinates Down =
            new MatrixCoordinates(1, 0);

        internal static readonly MatrixCoordinates Left =
=======
        /// <summary>
        /// Coordinates to add to the current player location, in order to move in up direction.
        /// </summary>
        public static readonly MatrixCoordinates Up =
            new MatrixCoordinates(-1, 0);

        /// <summary>
        /// Coordinates to add to the current player location, in order to move in right direction.
        /// </summary>
        public static readonly MatrixCoordinates Right =
            new MatrixCoordinates(0, 1);

        /// <summary>
        /// Coordinates to add to the current player location, in order to  move in down direction.
        /// </summary>
        public static readonly MatrixCoordinates Down =
            new MatrixCoordinates(1, 0);

        /// <summary>
        /// Coordinates to add to the current player location, in order to move left up direction.
        /// </summary>
        public static readonly MatrixCoordinates Left =
>>>>>>> 9cb912cd66b1a44b4cfde2bec4adc5a9d1c36a4e
            new MatrixCoordinates(0, -1);
    }
}
