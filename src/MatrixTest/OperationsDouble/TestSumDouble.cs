﻿using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestSumDouble
    {

        [TestMethod]
        public void SumZerosMatrixDouble()
        {
            double[,] resultMatr = new double[5, 7];
            Matrix<double> A = new Matrix<double>((uint)5, (uint)7, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)5, (uint)7, MatrixType.zeros);

            Sum<double> sum = new Sum<double>(A, B);

            Matrix<double> C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void SumUsersMatrixDouble()
        {
            double[,] MatrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            double[,] resultMatr = new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            Matrix<double> A = new Matrix<double>((uint)4, (uint)3, MatrA);
            Matrix<double> B = new Matrix<double>((uint)4, (uint)3, MatrA);

            Sum<double> sum = new Sum<double>(A, B);

            Matrix<double> C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void SumMatrixExceptionDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)4, (uint)5, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)5, (uint)4, MatrixType.zeros);
            Sum<double> SM = new Sum<double>(A, B);

            bool Except = false;

            try
            {
                Matrix<double> M = SM.Calculate();
            }
            catch (MatrixException)
            {
                Except = true;
            }

            Assert.IsTrue(Except);
        }

        [TestMethod]
        public void GetSetSumMatrixDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)4, (uint)5, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            double[,] MatrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            double[,] resultMatr = new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            Matrix<double> C = new Matrix<double>((uint)4, (uint)3, MatrA);
            Matrix<double> D = new Matrix<double>((uint)4, (uint)3, MatrA);
            Sum<double> SM = new Sum<double>(A, B);

            SM.MatrixLeft = C;
            SM.MatrixRight = D;

            CollectionAssert.AreEqual(SM.MatrixLeft.Get2DArray(), C.Get2DArray());
            CollectionAssert.AreEqual(SM.MatrixRight.Get2DArray(), C.Get2DArray());

        }
    }
}
