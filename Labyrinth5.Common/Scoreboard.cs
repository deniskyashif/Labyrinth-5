// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class processing game high score data 
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Labyrinth5.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    ///   Class processing game high score data. 
    /// </summary>
    public class Scoreboard 
    {
        private const string PrintPattern = "{0}. {1}-->{2}";
        private const string SavePattern = "{0}/{1}/{2}";            
        private const int ScoreboardMaxLenght = 10;
        private const string EmptyMessage = "The scoreboard is empty.";
        private string defaultPath = "../../Save/SavedScores.txt";
        private OrderedMultiDictionary<int, string> data;

        public Scoreboard()
        {
            this.data = new OrderedMultiDictionary<int, string>(false);
            this.ReadSavedScores();
        }
 
        /// <summary>
        /// Gets the worst score from the current game only.
        /// </summary>
        /// <returns>Worst score.</returns>
        public int GetWorstScore()
        {
            int worstScore = 0;
            foreach (var score in this.data.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }
       
        /// <summary>
        /// Displays the current scoreboard on the Console.
        /// </summary>
        public List<string> GetScore()
        {
            List<string> scoreboard = this.ExtractHighScore(PrintPattern);
            return scoreboard;
        }

        /// <summary>
        /// Reads previously saved scores and appends them to the current game scoreboard data.
        /// </summary>
        public void ReadSavedScores()
        {
            try
            {
                StreamReader reader = new StreamReader(this.defaultPath);
                using (reader)
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string[] splitData = line.Split('/');
                        int score;
                        bool result = Int32.TryParse(splitData[2], out score);
                        string userName = splitData[1];
                        this.data.Add(score, userName);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(
                    "Can not find 'Save/SavedScores.txt'.");
            }
        }

        /// <summary>
        /// Saves the current game data to the designated save file.
        /// </summary>
        public void UptadeSavedScore() 
        {
            StreamWriter writer = new StreamWriter(this.defaultPath, true);
            List<string> scoreboard = this.ExtractHighScore(SavePattern);
            if (scoreboard[0] == EmptyMessage)
            {
                Console.WriteLine(EmptyMessage);
            }
            else
            {
                using (writer)
                {
                    for (int i = 0; i < scoreboard.Count; i++)
                    {
                        writer.WriteLine(scoreboard[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Simultaneously updates the in-game scoreboard and the external Save file.
        /// </summary>
        /// <param name="playerScore">The score of the last player.</param>
        /// <param name="userName"> The name of the last player.</param>
        public void UpdateScoreBoard(int playerScore, string userName)
        {
            this.data.Add(playerScore, userName);
            this.UptadeSavedScore();
        }

        /// <summary>
        /// Returns a list of formatted highScore.
        /// </summary>
        /// <param name="pattern">Pattern for formatting the score strings.</param>
        /// <returns>List of scores.</returns>
        private List<string> ExtractHighScore(string pattern)
        {
            int counter = 1;
            List<string> scoreboard = new List<string>();
            if (this.data.Count == 0)
            {
                scoreboard.Add(EmptyMessage);
            }
            else
            {
                foreach (var score in this.data)
                {
                    if (counter > ScoreboardMaxLenght)
                    {
                        break;
                    }
                    else
                    {
                        var foundScore = this.data[score.Key];
                        foreach (var name in foundScore)
                        {
                            StringBuilder formatedScore = new StringBuilder();
                            formatedScore.AppendFormat(pattern, counter, name, score.Key);
                            scoreboard.Add(formatedScore.ToString());
                        }
                    }

                    counter++;
                }
            }

            return scoreboard;
        }
    }
}