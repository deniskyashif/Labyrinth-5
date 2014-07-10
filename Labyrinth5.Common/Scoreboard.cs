namespace Labyrinth5.Common
{
    using System;
    using Wintellect.PowerCollections;
    using System.IO;

    public sealed class Scoreboard 
    {
        //TODO: consider renaming scoreboard
        private OrderedMultiDictionary<int, string> data;
        private static string path = "Save/SavedScores.txt";
        private const int SCOREBOARD_MAX_LENGHT = 10;
        private const string EMPTY_MESSAGE = "The scoreboard is empty.";
        private static readonly Scoreboard instance = new Scoreboard();

        private Scoreboard()
        {
            this.data = new OrderedMultiDictionary<int, string>(false);
            ReadSavedScores();
        }

        public static Scoreboard Instance
        {
            get
            {
                return instance;
            }
        }

        public int GetWorstScore()
        {
            int worstScore = 0;
            foreach (var score in this.data.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        public override string ToString()
        {
            int counter = 1;
            string scoreboard = "";
            if (this.data.Count == 0)
            {
                scoreboard = EMPTY_MESSAGE;

            }
            else
            {
                foreach (var score in this.data)
                {
                    if (counter > SCOREBOARD_MAX_LENGHT)
                    {
                        break;
                    }
                    else
                    {
                        var foundScore = this.data[score.Key];
                        foreach (var equalScore in foundScore)
                        {
                            scoreboard += ("/" + counter + ". " + equalScore + "-->" + score.Key);
                        }
                    }
                    counter++;
                }
            }
            return scoreboard;
        }

        public void PrintScore()
        {
                string scoreboard = this.ToString();
                if (scoreboard == EMPTY_MESSAGE)
                {
                    Console.WriteLine(scoreboard);
                }
                else
                {
                    string[] scroboardSplit = scoreboard.Split('/');

                    for (int i = 0; i < scroboardSplit.Length; i++)
                    {
                        Console.WriteLine(scroboardSplit[i]);
                    }
                }

            Console.WriteLine();
        }

        //TODO: writing in the file should be done in the format: score/name
        public void ReadSavedScores()
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                using (reader)
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
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(
                  "Can not find 'Save/SavedScores.txt'.");
            }
        }

        //TODO: Name should be requested from the command executor.
        //TODO: implement high score
        public void UptadeSavedScore() 
        {
            StreamWriter writer = new StreamWriter(path);
            string scoreboard = this.ToString();
            if (scoreboard == EMPTY_MESSAGE)
            {
                Console.WriteLine(scoreboard);
            }
            else
            {
                using (writer)
                {
                    string[] scroboardSplit = scoreboard.Split('/');
                    for (int i = 0; i < scroboardSplit.Length; i++)
                    {
                        writer.WriteLine(scroboardSplit[i]);
                    }
                }
            }
        }


        public void UpdateScoreBoard(int currentNumberOfMoves, string userName)
        {
            this.data.Add(currentNumberOfMoves, userName);
            UptadeSavedScore();
        }
    }
}
