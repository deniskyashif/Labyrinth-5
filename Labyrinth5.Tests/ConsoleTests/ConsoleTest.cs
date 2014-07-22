namespace Labyrinth5.Tests.ConsoleTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth5.Common.Engine;
    using System.IO;

    [TestClass]
    public class ConsoleTest
    {
        [TestMethod]
        public void CheckForInvalidMoveCommand()
        {
            
            string inputCommands = string.Format("{0}move up{0}end", Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(inputCommands))
                {
                    //code needed to run the command
                    var engine = ConsoleEngine.Instance;

                    Console.SetIn(stringReader);
                    engine.Run();

                    /*split console output by line into string array
                    and assume the output is the content on the last line*/
                    var separators = Environment.NewLine.ToCharArray();
                    string consoleOutput = stringWriter.ToString();

                    //NOTE: doesn't split correctly
                    var outputLines = consoleOutput.Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);

                    string expected = "Illegal move";
                    var outputLineIndex = outputLines.Length - 1;
                    string result = outputLines[outputLineIndex];
                    Assert.AreEqual<string>(expected, result);
                }
            }
        }
    }
}
