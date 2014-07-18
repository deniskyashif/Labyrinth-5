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
<<<<<<< HEAD
    internal interface ICommandInterpreter
=======
    /// <summary>
    /// Defines an ICommandInterpreter interface.
    /// </summary>
    public interface ICommandInterpreter
>>>>>>> 9cb912cd66b1a44b4cfde2bec4adc5a9d1c36a4e
    {
        /// <summary>
        /// Reads and initiates commands.
        /// </summary>
        /// <param name="command">Command name.</param>
        void ParseAndDispatch(string command);
    }
}
