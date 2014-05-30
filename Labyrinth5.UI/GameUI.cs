namespace Labyrinth5.UI
{
    using System;
    using Labyrinth5.Common;
    
    class GameUI
    {
        static void Main()
        {
            var test = new CommandExecutor();
            var p = new Player();
            var m = new Maze();
            var sc = new Scoreboard();
            
            test.PlayGame(p,m,sc);
        }
    }
}