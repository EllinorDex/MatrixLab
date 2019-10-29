using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;


namespace MatrixTest
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void ConstractOnesMatrixNorm()
        {
            uint length = 5;
            Matrix A = new Matrix(length, length, "ones");
            Assert.AreEqual(length, A.CountOfColumns);
            Assert.AreEqual(length, A.CountOfRows);

            Assert.AreEqual(1, A[2, 2]);
            Assert.AreEqual(0, A[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangle()
        {
            uint lengthCol = 5;
            uint lengthRow = 7;
            //Проверил на матричное исключение
            Assert.ThrowsException<MatrixException>(() => new Matrix(lengthRow, lengthCol, "ones"));

        }

        [TestMethod]
        public void ConstractZerosMatrixNorm()
        {
            uint lengthCol = 5;
            uint lengthRow = 7;
            Matrix A = new Matrix(lengthRow, lengthCol, "zeros");
            Assert.AreEqual(lengthCol, A.CountOfColumns);
            Assert.AreEqual(lengthRow, A.CountOfRows);

            for (int i = 0, j = 0; i < A.CountOfColumns && j < A.CountOfRows; ++i, ++j)
                Assert.AreEqual(0, A[i, j]);
        }

        [TestMethod]
        public void ConstractUsersMatrixNorm()
        {
            uint lengthCol = 2;
            uint lengthRow = 3;
            int[,] Matr = new int[lengthCol, lengthRow];
            //Matr = { {1, 2, 3}, {4, 5, 6} };

            //Matrix A = new Matrix(lengthRow, lengthCol, );
            //Assert.AreEqual(lengthCol, A.CountOfColumns);
            //Assert.AreEqual(lengthRow, A.CountOfRows);

            //for (int i = 0, j = 0; i < A.CountOfColumns && j < A.CountOfRows; ++i, ++j)
            //    Assert.AreEqual(0, A[i, j]);
        }

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
