namespace Labyrinth5.Common
{
    using System;
    using Wintellect.PowerCollections;

    public class Scoreboard
    {
        private OrderedMultiDictionary<int, string> scoreboard;

        public Scoreboard()
        {
            this.scoreboard = new OrderedMultiDictionary<int, string>(false);
        }

        public int GetWorstScore()
        {
            int worstScore = 0;
            foreach (var score in this.scoreboard.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        public void PrintScore()
        {
            int counter = 1;

            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");

            }
            else
            {
                foreach (var score in this.scoreboard)
                {
                    var foundScore = this.scoreboard[score.Key];

                    foreach (var equalScore in foundScore)
                    {
                        Console.WriteLine("{0}. {1} --> {2}", counter, equalScore, score.Key);

                    }
                    counter++;
                }
            }


            Console.WriteLine();
        }

        public void UpdateScoreBoard(int currentNumberOfMoves)
        {
            string userName = string.Empty;

            if (this.scoreboard.Count < 5)
            {
                while (userName == string.Empty)
                {
                    Console.WriteLine("**Please put down your name:**");
                    userName = Console.ReadLine();
                }
                this.scoreboard.Add(currentNumberOfMoves, userName);
            }
            else
            {
                int worstScore = this.GetWorstScore();
                if (currentNumberOfMoves <= worstScore)
                {
                    if (this.scoreboard.ContainsKey(currentNumberOfMoves) == false)
                    {
                        this.scoreboard.Remove(worstScore);
                    }
                    while (userName == string.Empty)
                    {
                        Console.WriteLine("**Please put down your name:**");
                        userName = Console.ReadLine();
                    }
                    this.scoreboard.Add(currentNumberOfMoves, userName);
                }
            }
        }
    }
}
