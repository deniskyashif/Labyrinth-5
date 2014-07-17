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
        /// Constructor. Gets player and asigns it to the Player field.
        /// </summary>
        /// <param name="player">Player</param>
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
