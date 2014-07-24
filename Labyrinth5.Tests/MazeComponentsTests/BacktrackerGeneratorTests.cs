using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth5.Common.MazeComponents.Generators;
using Labyrinth5.Common.MazeComponents.Cells;
using System.Collections.Generic;

namespace Labyrinth5.Tests.MazeTests
{
    [TestClass]
    public class BacktrackerGeneratorTests
    {
        [TestMethod]
        public void GenerateReturnsBacktrackerCellArray()
        {
            BacktrackerMazeGenerator generator = new BacktrackerMazeGenerator();
            var array = generator.Generate(10, 10);
            Assert.IsInstanceOfType(array, typeof(Array));
        }
    }
}
