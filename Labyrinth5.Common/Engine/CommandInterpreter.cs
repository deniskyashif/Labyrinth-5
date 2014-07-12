namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.MazeComponents;
    using System;

    /// <summary>
    /// Reads and handles all user input
    /// </summary>
    internal class CommandInterpreter
    {
        public CommandInterpreter()
        {
        }

        /// <summary>
        /// Checks if direction is allowed on move command.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="maze"></param>
        /// <param name="command">Player input</param>
        /// <returns></returns>
        private bool IsMoveLegal(Player player, Maze maze, string command)
        {
            if (command == "A")
            {
                if (maze[player.Row, player.Col - 1].IsWall)
                {
                    return false;
                }
            }
            if (command == "S")
            {
                if (maze[player.Row + 1, player.Col].IsWall)
                {
                    return false;
                }
            }
            if (command == "D")
            {
                if (maze[player.Row, player.Col + 1].IsWall)
                {
                    return false;
                }
            }
            if (command == "W")
            {
                if (maze[player.Row - 1, player.Col].IsWall)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calls the command and error methods based on command string.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="maze"></param>
        /// <param name="command">Player input</param>
        public void ExecuteCommand(Player player, Maze maze, string command)
        {
            if (command == "A" || command == "S" || command == "D" || command == "W")
            {
                MovePlayer(player, maze, command);
            }
        }

        /// <summary>
        /// Calls player.Move based on command string.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="maze"></param>
        /// <param name="command">Player input</param>
        public void MovePlayer(Player player, Maze maze, string command)
        {
            if (IsMoveLegal(player, maze, command))
            {
                if (command == "A")
                {
                    player.Move(0, -1);
                }
                else if (command == "S")
                {
                    player.Move(1, 0);
                }
                else if (command == "D")
                {
                    player.Move(0, 1);
                }
                else if (command == "W")
                {
                    player.Move(-1, 0);
                }
            }
        }
        /*
         * Command handlers to be implemented(obligatory):
         * - top (show ranking)
         * - (re)start
         * - exit
         * 
         * (non-obligatory extensions)
         * - solve maze
         * ...
         * */
    }
}