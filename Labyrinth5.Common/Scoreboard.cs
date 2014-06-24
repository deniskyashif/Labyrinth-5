namespace Labyrinth5.Common
{
    using System;
    using Wintellect.PowerCollections;
    using System.IO;

    public class Scoreboard
    {
        //TODO: consider renaming scoreboard
        private OrderedMultiDictionary<int, string> scoreboard;
        private StreamReader reader = new StreamReader("Save/SavedScores.txt");
        private StreamWriter writer = new StreamWriter("Save/SavedScores.txt");

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

        //TODO: writing in the file should be done in the format: score/name
        public void ReadSavedScores()
        {
            using (this.reader)
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] splitData = line.Split('/');
                    int score;
                    bool result = Int32.TryParse(splitData[0], out score);
                    string userName = splitData[1];
                    UpdateScoreBoard(score, userName);
                }
            }
        }

        //TODO: Name should be requested from the command executor.
        //TODO: Implement saving to the file

        public void UpdateScoreBoard(int currentNumberOfMoves, string userName)
        {
            this.scoreboard.Add(currentNumberOfMoves, userName);
        }
    }
}
