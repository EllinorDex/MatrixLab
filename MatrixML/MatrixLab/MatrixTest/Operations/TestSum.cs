using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixTest
{
    [TestClass]
    public class TestSum
    {

        [TestMethod]
        public void UseSumMatrix()
        {
            uint lengthCol = 5;
            uint lengthRow = 7;
            Matrix A = new Matrix(lengthRow, lengthCol, "zeros");
            Matrix B = new Matrix(lengthRow, lengthCol, "zeros");

            Sum sum = new Sum();
            sum.MatrixLeft = A;
            sum.MatrixRight = B;
            Matrix C = sum.GetResult();

            for (int i = 0, j = 0; i < C.CountOfColumns && j < C.CountOfRows; ++i, ++j)
                Assert.AreEqual(0, C[i, j]);
        }
    }
}
