// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerMoveCommand.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//  Internal class that executes the players movement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;

    /// <summary>
    /// Internal class that executes the players movement.
    /// </summary>
    internal class PlayerMoveCommand : ICommand
    {
        /// <summary>
        /// A player to execute the command on.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMoveCommand"/> class.
        /// </summary>
        /// <param name="player">An instance of Player class.</param>
        public PlayerMoveCommand(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Implements the ICommand interface.
        /// </summary>
        public void Execute()
        {
            this.player.Move();
        }
    }
}
