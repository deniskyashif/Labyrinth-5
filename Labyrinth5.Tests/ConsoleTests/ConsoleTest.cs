using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth5.Common.Engine;
using System.IO;

namespace Labyrinth5.Tests.ConsoleTests
{
    [TestClass]
    public class ConsoleTest
    {
        [TestMethod]
        public void CheckForInvalidMoveCommand()
        {
            
            string command = "move w";

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(command))
                {
                    Console.SetIn(stringReader);

                    //code needed to run the command
                    var engine = ConsoleEngine.Instance;
                    engine.Run();

                    /*split console output by line into string array
                    and assume the output is the content on the last line*/
                    string consoleOutput = stringWriter.ToString();
                    var lines = consoleOutput.Split(new[] { Environment.NewLine }, 
                        StringSplitOptions.RemoveEmptyEntries);


                    string result = lines[lines.Length - 2];
                    string expected = "Illegal move";
                    Assert.AreEqual<string>(expected, result);
                }
            }
        }
    }
}
