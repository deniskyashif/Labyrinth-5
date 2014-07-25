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
    /// Defines ICommand interface.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes the Command.
        /// </summary>
        void Execute();
    }
}
