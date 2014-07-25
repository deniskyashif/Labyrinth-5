namespace Labyrinth5.Tests.ConsoleTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth5.Common.Engine;
    using System.IO;
    using System.Windows.Forms;

    [TestClass]
    public class CommandInterpreterTests
    {
        [TestMethod]
        public void CheckForInvalidMoveCommand()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                var interpreter = new CommandInterpreter();
                interpreter.ParseAndDispatch("init");
                interpreter.ParseAndDispatch("move left");

                string consoleOutput = stringWriter.ToString();
                string expected = "Illegal Move";

                Assert.IsTrue(consoleOutput.IndexOf(expected) > -1);
            }
        }

        [TestMethod]
        public void CheckSetBacktrackerAlgorithmCommand()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                var interpreter = new CommandInterpreter();
                interpreter.ParseAndDispatch("init");
                interpreter.ParseAndDispatch("set backtracker");

                string consoleOutput = stringWriter.ToString();
                string expected = "Generation algorithm set to : backtracker";

                Assert.IsTrue(consoleOutput.IndexOf(expected) > -1);
            }
        }

        [TestMethod]
        public void CheckSetPrimAlgorithmCommand()
        {

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                var interpreter = new CommandInterpreter();
                interpreter.ParseAndDispatch("init");
                interpreter.ParseAndDispatch("set prim");

                string consoleOutput = stringWriter.ToString();
                string expected = "Generation algorithm set to : prim";

                Assert.IsTrue(consoleOutput.IndexOf(expected) > -1);
            }
        }

        [TestMethod]
        public void CheckForInvalidCommand()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                var interpreter = new CommandInterpreter();
                interpreter.ParseAndDispatch("x");
                
                string consoleOutput = stringWriter.ToString();
                string expected = "Invalid Command";

                Assert.IsTrue(consoleOutput.IndexOf(expected) > -1);
            }
        }
    }
}
