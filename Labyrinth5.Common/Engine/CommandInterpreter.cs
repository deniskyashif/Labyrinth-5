namespace Labyrinth5.Common.Engine
{
    using Labyrinth5.Common.MazeComponents;
    using System;

    internal class CommandInterpreter
    {

        public CommandInterpreter()
        {
        }

        public void ExecuteCommand(Player player, Maze maze, string command)
        {
            if (command == "A" || command == "S" || command == "D" || command == "W")
            {
                MovePlayer(player, maze, command);
            }
        }
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
