// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreboardManager.cs" company="Team-Labyrint5">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class processing game high score data. 
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
    public class ScoreboardManager
    {
        /// <summary>
        /// Pattern for printing the scoreboard lines.
        /// </summary>
        private const string PrintPattern = "{0}. {1}-->{2}";

        /// <summary>
        /// Pattern for saving scoreboard lines.
        /// </summary>
        private const string SavePattern = "{0}/{1}/{2}";

        /// <summary>
        /// Max length of saved scores.
        /// </summary>
        private const int ScoreboardMaxLenght = 10;

        /// <summary>
        /// Scoreboard is empty message.
        /// </summary>
        private const string EmptyMessage = "The scoreboard is empty.";

        /// <summary>
        /// Path to the file with the scoreboard entries.
        /// </summary>
        private string filePath = "../../../Labyrinth5.Common/Save/SavedScores.txt";

        /// <summary>
        /// Array of char separators used for splitting semantically the content of a text.
        /// </summary>
        private char[] separators;

        /// <summary>
        /// Ordered dictionary holding data value pair: score name.
        /// </summary>
        private OrderedMultiDictionary<int, string> scoreboardData;

        /// <summary>
        /// Initializes a new instance of the<see cref="ScoreboardManager"/> class.
        /// </summary>
        /// <param name="filePath">The path to the file where the ranking is stored.</param>
        /// <param name="separators">Array of separators using which the file is separated to
        /// semantically relevant segments.</param>
        public ScoreboardManager(string filePath, char[] separators)
        {
            this.filePath = filePath;
            this.separators = separators;
            this.scoreboardData = new OrderedMultiDictionary<int, string>(false);
            this.ReadSavedScores();
        }

        /// <summary>
        /// Gets the worst score from the current game only.
        /// </summary>
        /// <returns>Worst score.</returns>
        public int GetWorstScore()
        {
            int worstScore = 0;

            foreach (var score in this.scoreboardData.Keys)
            {
                worstScore = score;
            }

            return worstScore;
        }

        /// <summary>
        /// Gets a string list of the current scoreboard.
        /// </summary>
        /// <returns>List of the current scoreboard.</returns>
        public List<string> GetScoresList()
        {
            List<string> scoreboard = this.ExtractHighScores(PrintPattern);
            return scoreboard;
        }

        /// <summary>
        /// Reads previously saved scores and appends them to the current game scoreboard data.
        /// </summary>
        public void ReadSavedScores()
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.filePath))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string[] splitData = line.Split(this.separators);
                        int score;
                        bool result = int.TryParse(splitData[2], out score);
                        string userName = splitData[1];
                        this.scoreboardData.Add(score, userName);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(
                    "Can not find the specified file.");
            }
        }

        /// <summary>
        /// Saves the current game data to the designated save file.
        /// </summary>
        public void UptadeSavedScore()
        {
            List<string> scoreboard = this.ExtractHighScores(SavePattern);

            if (scoreboard[0] == EmptyMessage)
            {
                Console.WriteLine(EmptyMessage);
            }
            else
            {
                File.WriteAllText(this.filePath, string.Empty);

                using (StreamWriter writer = new StreamWriter(this.filePath, true))
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
            this.scoreboardData.Add(playerScore, userName);
            this.UptadeSavedScore();
        }

        /// <summary>
        /// Returns a list of formatted highScores.
        /// </summary>
        /// <param name="pattern">Pattern for formatting the score strings.</param>
        /// <returns>List of scores.</returns>
        private List<string> ExtractHighScores(string pattern)
        {
            int counter = 1;
            List<string> scoreboard = new List<string>();

            if (this.scoreboardData.Count == 0)
            {
                scoreboard.Add(EmptyMessage);
            }
            else
            {
                foreach (var score in this.scoreboardData.Reversed())
                {
                    if (counter > ScoreboardMaxLenght)
                    {
                        break;
                    }
                    else
                    {
                        var foundScore = this.scoreboardData[score.Key];
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