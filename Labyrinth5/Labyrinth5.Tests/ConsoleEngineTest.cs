using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth5.Common.Engine;
using Labyrinth5.Common.Contracts;

namespace Labyrinth5.Tests
{
    [TestClass]
    public class ConsoleEngineTest
    {
        [TestMethod]
        public void EngineIstanceOfIEngineTest()
        {
            ConsoleEngine engineInstance = ConsoleEngine.Instance;
            Assert.IsTrue(engineInstance is IEngine);
        }
    }
}
