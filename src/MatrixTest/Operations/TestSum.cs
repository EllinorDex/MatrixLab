﻿using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.Operations
{
    [TestClass]
    public class TestSum
    {

        [TestMethod]
        public void SumZerosMatrix()
        {
            var resultMatr = new int[5, 7];
            var a = new Matrix<int>(5, 7, MatrixType.Zeros);
            var b = new Matrix<int>(5, 7, MatrixType.Zeros);

            var sum = new Sum<int>(a, b);

            var c = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        [TestMethod]
        public void SumUsersMatrix()
        {
            var matrA = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var resultMatr = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            var a = new Matrix<int>(4, 3, matrA);
            var b = new Matrix<int>(4, 3, matrA);

            var sum = new Sum<int>(a, b);

            var c = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        [TestMethod]
        public void SumMatrixException()
        {
            var a = new Matrix<int>(4, 5, MatrixType.Zeros);
            var b = new Matrix<int>(4, 4, MatrixType.Zeros);
            var sm = new Sum<int>(a, b);

            var except = false;

            try
            {
                var m = sm.Calculate();
            }
            catch (MatrixException)
            {
                except = true;
            }

            Assert.IsTrue(except);
        }

    }
}
