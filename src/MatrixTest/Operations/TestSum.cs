﻿using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixTest
{
    [TestClass]
    public class TestSum
    {

        [TestMethod]
        public void SumZerosMatrix()
        {
            int[,] resultMatr = new int[5, 7];
            Matrix A = new Matrix((uint)7, (uint)5, MatrixType.zeros);
            Matrix B = new Matrix((uint)7, (uint)5, MatrixType.zeros);

            Sum sum = new Sum(A, B);

            Matrix C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.GetMatrix());
        }

        [TestMethod]
        public void SumUsersMatrix()
        {
            int[,] MatrA = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] resultMatr = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            Matrix A = new Matrix((uint)7, (uint)4, MatrA);
            Matrix B = new Matrix((uint)7, (uint)4, MatrA);

            Sum sum = new Sum(A, B);

            Matrix C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.GetMatrix());
        }

        [TestMethod]
        public void SumMatrixException()
        {
            Matrix A = new Matrix((uint)7, (uint)5, MatrixType.zeros);
            Matrix B = new Matrix((uint)5, (uint)5, MatrixType.zeros);

            Sum sum = new Sum(A, B);

            Assert.ThrowsException<MatrixException>(() => sum.Calculate());
            Matrix C = sum.Calculate();
            int[,] resultMatr = new int[5, 7];

            CollectionAssert.AreEqual(resultMatr, C.GetMatrix());
        }
    }
}