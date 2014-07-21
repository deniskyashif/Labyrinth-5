using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth5.Common.MazeComponents;
using Labyrinth5.Common.MazeComponents.Cells;
using Labyrinth5.Common;
namespace Labyrinth5.Tests.MazeTests
{
    [TestClass]
    public class PrimMazeCellTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatrixCoordinatesThrowExcepion()
        {
            PrimCell cell = new PrimCell(0, 0);
            cell.Position = new MatrixCoordinates(-10, -10);
        }
    }
}
