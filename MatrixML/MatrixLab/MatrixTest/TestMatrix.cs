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

            int[,] Matr = new int[lengthCol, lengthRow];

            CollectionAssert.AreEqual(Matr, A.GetMatrix());
        }

        [TestMethod]
        public void ConstractUsersMatrixNorm()
        {
            uint lengthCol = 2;
            uint lengthRow = 3;
            int[,] Matr = new int[,] { {1, 2, 3}, {4, 5, 6} };

            Matrix A = new Matrix(lengthRow, lengthCol, Matr);
            CollectionAssert.AreEqual(Matr, A.GetMatrix());
        }

        [TestMethod]
        public void MethodGetMatrixRectangle()
        {
            uint lengthCol = 2;
            uint lengthRow = 3;
            int[,] Matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix A = new Matrix(lengthRow, lengthCol, Matr);
            int[,] MatrA = A.GetMatrix();
            MatrA[1, 1] = 10;

            Assert.AreEqual(Matr[1, 1], A[1, 1]);
        }

<<<<<<< HEAD
=======
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
>>>>>>> de016bd21cc1f1a5e31600f9584a45890c0a9b6d
    }
}
