namespace Labyrinth5.Tests.MatrixTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth5.Common;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CheckMatrixRowValueForProperPlusOperatorResult()
        {
            // arrange
            var point1 = new MatrixCoordinates(1, 1);
            var point2 = new MatrixCoordinates(2, 2);
            var expectedRowValue = 3;

            // action
            var result = point1 + point2;

            // assert
            Assert.AreEqual(expectedRowValue, result.Row, "Plus Operator for the Row is not correct");
        }

        [TestMethod]
        public void CheckMatrixColValueForProperPlusOperatorResult()
        {
            // arrange
            var point1 = new MatrixCoordinates(1, 1);
            var point2 = new MatrixCoordinates(2, 2);
            var expectedRowValue = 3;

            // action
            var result = point1 + point2;

            // assert
            Assert.AreEqual(expectedRowValue, result.Col, "Plus Operator for the Col is not correct");
        }

        [TestMethod]
        public void CheckMatrixRowValueForProperMinusOperatorResult()
        {
            // arrange
            var point1 = new MatrixCoordinates(2, 2);
            var point2 = new MatrixCoordinates(1, 1);
            var expectedColValue = 1;

            // action
            var result = point1 - point2;

            // assert
            Assert.AreEqual(expectedColValue, result.Row, "Minus Operator for the Row is not correct");
        }

        [TestMethod]
        public void CheckMatrixColValueForProperMinusOperatorResult()
        {
            // arrange
            var point1 = new MatrixCoordinates(2, 2);
            var point2 = new MatrixCoordinates(1, 1);
            var expectedColValue = 1;

            // action
            var result = point1 - point2;

            // assert
            Assert.AreEqual(expectedColValue, result.Col, "Minus Operator for the Col is not correct");
        }

        [TestMethod]
        public void CheckForProperToStringOutput()
        {
            // arrage
            var point = new MatrixCoordinates(1, 1);
            var expected = "(1, 1)";

            // action
            var result = point.ToString();

            // assert
            Assert.AreEqual(expected, result, "ToString Method does not return expected result");
        }

        [TestMethod]
        public void CheckForProperEqualsMethodBehaviour() 
        {
            // arange
            var point = new MatrixCoordinates(1, 1);
            var compareObj = new MatrixCoordinates(1, 1);

            // action
            var result = point.Equals(compareObj);

            // assert
            Assert.AreEqual(true, result, "Equals method does not work proper");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void CheckForInvalidTypeCastByEqualsMethod()
        {
            // arange
            var point = new MatrixCoordinates(1, 1);
            var compareObj = new
            {
                Row = 1,
                Col = 1
            };

            // action
            point.Equals(compareObj);
        }
    }
}
