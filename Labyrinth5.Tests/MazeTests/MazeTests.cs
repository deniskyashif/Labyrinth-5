namespace Labyrinth5.Tests.MazeTests
{
    using System;
    using Labyrinth5.Common;
    using Labyrinth5.Common.MazeComponents;
    using Labyrinth5.Common.MazeComponents.Cells;
    using Labyrinth5.Common.MazeComponents.Generators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        public void CheckIfTopLeftRowPositionIsCorrect()
        {
            BacktrackerMazeGenerator generator = new BacktrackerMazeGenerator();
            Maze maze = new Maze(generator, 10, 10);
            Assert.AreEqual(10, maze.TopLeftPosition.Row);
        }

        [TestMethod]
        public void CheckIfTopLeftColPositionIsCorrect()
        {
            BacktrackerMazeGenerator generator = new BacktrackerMazeGenerator();
            Maze maze = new Maze(generator, 20, 20);
            Assert.AreEqual(20, maze.TopLeftPosition.Row);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfNegativePrimcellCoordinatesThrowException()
        {
            PrimCell primcell = new PrimCell(-2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfNegativeBacktrackercellCoordinatesThrowException()
        {
            BacktrackerCell backtrackerCell = new BacktrackerCell(-3, -3);
        }

        [TestMethod]
        public void CheckIfMazeIsCorrect()
        {
           
        }
    }
}
