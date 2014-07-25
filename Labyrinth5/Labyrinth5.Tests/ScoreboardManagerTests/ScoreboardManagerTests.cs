namespace Labyrinth5.Tests.ScoreboardTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using Labyrinth5.Common;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class ScoreboardManagerTests
    {
        [TestMethod]
        public void TestGetScoreMethodForMaximumListCount()
        {
            // arrange
            string testSavedScoresPath = "../../../Labyrinth5.Common/Save/testSavedScores.txt";

            var scoreBoard = new ScoreboardManager(testSavedScoresPath, new []{'/'});
            FillTestedScoreBoard(scoreBoard, testSavedScoresPath);

            var expectedMaxScoreListCount = 10;

            // action
            var result = scoreBoard.GetScoresList().Count;

            // assert
            Assert.AreEqual(expectedMaxScoreListCount, result, "GetScore() returns more than 10 results.");
        }

        [TestMethod]
        public void TestGetScoreMethodForProperResultsRanking()
        {
            // arrange

            string testSavedScoresPath = "../../../Labyrinth5.Common/Save/testSavedScores.txt";

            var scoreBoard = new ScoreboardManager(testSavedScoresPath, new[]{'/'});
            FillTestedScoreBoard(scoreBoard, testSavedScoresPath);

            var expectedSaveScoreData = FillExpectedSaveScoreList();

            // action
            var result = scoreBoard.GetScoresList();

            // assert
            CollectionAssert.AreEqual(expectedSaveScoreData, result, "Ranking is not correct!");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestForInvalidScoreBoardDirectoryPath()
        {
            // arrange
            var invalidFilePath = "../invalidDirectoryLocation/IdoNotKnowWhere/someInvalidFile.txt";
            var scoreBoard = new ScoreboardManager(invalidFilePath, new[]{'/'});
            scoreBoard.ReadSavedScores();
        }

        private void FillTestedScoreBoard(ScoreboardManager obj, string path)
        {
            for (int i = 0; i < 20; i++)
            {
                string currentPlayer = "Player" + i;
                int currentPlayerScore = (i + 1) * 100;
                obj.UpdateScoreBoard(currentPlayerScore, currentPlayer);
            }
        }

        private List<string> FillExpectedSaveScoreList()
        {
            var listToReturn = new List<string>();
            var pattern = "{0}. {1}-->{2}";
            var sb = new StringBuilder();
            var rank = 1;

            for (int i = 19; i >= 0; i--)
            {
                string currentPlayer = "Player" + i;
                int currentPlayerScore = (i + 1) * 100;
                sb.AppendFormat(pattern, rank, currentPlayer, currentPlayerScore);
                listToReturn.Add(sb.ToString());
                sb.Clear();
                rank++;
            }

            return listToReturn.GetRange(0, 10);
        }
    }
}
