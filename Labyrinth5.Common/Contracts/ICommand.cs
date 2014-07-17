// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Defines an ICommand interface. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Contracts
{
    /// <summary>
    /// Defines an ICommand interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the Command.
        /// </summary>
        void Execute();
    }
}
