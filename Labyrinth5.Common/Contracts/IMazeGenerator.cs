// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMazeGenerator.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an IMazeGenerator interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
<<<<<<< HEAD
    internal interface IMazeGenerator
=======
    /// <summary>
    /// Defines an IMazeGenerator interface. 
    /// </summary>
    public interface IMazeGenerator
>>>>>>> 9cb912cd66b1a44b4cfde2bec4adc5a9d1c36a4e
    {
        /// <summary>
        /// Generates a MazeCell object matrix.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of cols.</param>
        /// <returns>MazeCell object matrix.</returns>
        IMazeCell[,] Generate(int rows, int columns);
    }
}
