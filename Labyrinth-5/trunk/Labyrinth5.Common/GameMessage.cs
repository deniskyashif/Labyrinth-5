namespace Labyrinth5.Common
{
    internal class GameMessage
    {
        public const string WELCOME = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top\nscoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        public const string WIN = "Congratulations! You've exited the labirynth in {0} moves.";
        public const string AskForMove = "Enter your move (L=left, R-right, U=up, D=down):";
        public const string InvalidInput = "Invalid input!";
        public const string PresKey = "**Press a key to continue**";

        public const string EmptyScoreBoard = "The scoreboard is empty.";
        public const string AskForName = "**Please put down your name:**";
    }
}
