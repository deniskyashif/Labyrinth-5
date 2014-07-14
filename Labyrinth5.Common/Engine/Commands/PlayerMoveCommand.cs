namespace Labyrinth5.Common.Engine.Commands
{
    using Labyrinth5.Common.Contracts;

    internal class PlayerMoveCommand : ICommand
    {
        private Player player;

        public PlayerMoveCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Move();
        }
    }
}
