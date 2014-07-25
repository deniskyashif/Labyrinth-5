// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandInterpreter.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an ICommandInterpreter interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
    /// <summary>
    /// Defines an ICommandInterpreter interface.
    /// </summary>
    internal interface ICommandInterpreter
    {
        /// <summary>
        /// Reads and initiates commands.
        /// </summary>
        /// <param name="command">Command name.</param>
        void ParseAndDispatch(string command);
    }
}
