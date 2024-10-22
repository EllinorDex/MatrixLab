﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void ConstractOnesMatrixNormDouble()
        {
            var a = Matrix<int>.CreateOnesMatrix(4, 4);
            var matr = new int[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangle()
        {
            Assert.ThrowsException<MatrixException>(() => Matrix<int>.CreateOnesMatrix(7, 5));
        }

        [TestMethod]
        public void ConstractZerosMatrixNorm()
        {
            var a = Matrix<int>.CreateZeroMatrix(5, 7);

            var matr = new int[5, 7];

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void ConstractUsersMatrixNorm()
        {
            var matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<int>(2, 3, matr);

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void MethodGetSizeMatrix()
        {
            var a = Matrix<int>.CreateOnesMatrix(5, 5);

            Assert.AreEqual(5, a.CountOfColumns);
            Assert.AreEqual(5, a.CountOfRows);
        }

        [TestMethod]
        public void MethodGetMatrixRectangle()
        {
            var matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<int>(2, 3, matr);
            var matrA = a.Get2DArray();
            matrA[1, 1] = 10;

            Assert.AreEqual(matr[1, 1], a[1, 1]);
        }

        [TestMethod]
        public void OperationEqualityTrue()
        {
            var matr = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void OperationEqualityFalse()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsFalse(a == b);
        }

        [TestMethod]
        public void OperationInequalityTrue()
        {
            var matr = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsFalse(a != b);
        }

        [TestMethod]
        public void OperationInequalityFalse()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsTrue(a != b);
        }

        [TestMethod]
        public void MethodGetHashCode()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            Assert.AreEqual(13000, a.GetHashCode());
        }

        [TestMethod]
        public void MethodEquals()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            Assert.IsTrue(a.Equals(a));
        }

    }
}
