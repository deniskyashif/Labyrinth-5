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
    /// <summary>
    /// Defines an IMazeGenerator interface. 
    /// </summary>
    public interface IMazeGenerator
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
