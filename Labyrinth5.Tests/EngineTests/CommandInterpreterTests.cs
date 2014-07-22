namespace Labyrinth5.Tests.ConsoleTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth5.Common.Engine;
    using System.IO;

    [TestClass]
    public class CommandInterpreterTests
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

                    string consoleOutput = stringWriter.ToString();
                    string expected = "Illegal Move";
                    var indexOfCommand = consoleOutput.IndexOf(expected);
                    bool doesExist = false;

                    if(indexOfCommand >=0) {
                        doesExist = true;
                    }

                    Assert.AreEqual(true, doesExist);
                    
                }
            }
        }

        [TestMethod]
        public void CheckSetBacktrackerAlgorithmCommand()
        {

            string inputCommands = string.Format("{0}set backtracker{0}end", Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(inputCommands))
                {
                    //code needed to run the command
                    var engine = ConsoleEngine.Instance;

                    Console.SetIn(stringReader);
                    engine.Run();

                    string consoleOutput = stringWriter.ToString();
                    string expected = "Generation algorithm set to : backtracker";
                    var indexOfCommand = consoleOutput.IndexOf(expected);
                    bool doesExist = false;

                    if (indexOfCommand >= 0)
                    {
                        doesExist = true;
                    }

                    Assert.AreEqual(true, doesExist);

                }
            }
        }

        [TestMethod]
        public void CheckSetPrimAlgorithmCommand()
        {

            string inputCommands = string.Format("{0}set prim{0}end", Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(inputCommands))
                {
                    //code needed to run the command
                    var engine = ConsoleEngine.Instance;

                    Console.SetIn(stringReader);
                    engine.Run();

                    string consoleOutput = stringWriter.ToString();
                    string expected = "Generation algorithm set to : prim";
                    var indexOfCommand = consoleOutput.IndexOf(expected);
                    bool doesExist = false;

                    if (indexOfCommand >= 0)
                    {
                        doesExist = true;
                    }

                    Assert.AreEqual(true, doesExist);

                }
            }
        }

        [TestMethod]
        public void CheckForInvalidCommand()
        {

            string inputCommands = string.Format("{0}fdsgrecxv{0}end", Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                using (StringReader stringReader = new StringReader(inputCommands))
                {
                    //code needed to run the command
                    var engine = ConsoleEngine.Instance;

                    Console.SetIn(stringReader);
                    engine.Run();

                    string consoleOutput = stringWriter.ToString();
                    string expected = "Invalid Command";
                    var indexOfCommand = consoleOutput.IndexOf(expected);
                    bool doesExist = false;

                    if (indexOfCommand >= 0)
                    {
                        doesExist = true;
                    }

                    Assert.AreEqual(true, doesExist);

                }
            }
        }
    }
}
