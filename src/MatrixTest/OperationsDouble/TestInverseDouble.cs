using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestInverseDouble
    {
        [TestMethod]
        public void InverseOnesMatrix()
        {
            Matrix<double> A = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            InverseMatrix<double> Matr = new InverseMatrix<double>(A);

            Matrix<double> Inverse = Matr.Calculate();

            CollectionAssert.AreEqual(A.Get2DArray(), Inverse.Get2DArray());
        }

        [TestMethod]
        public void InverseUsersMatrix0Double()
        {
            double[,] matrOfArray = new double[,] { { 2, 6, 5 }, { 5, 3, -2 }, { 7, 4, -3 } };
            double[,] resultMatr = new double[,] { { 1, -38, 27 }, { -1, 41, -29 }, { 1, -34, 24 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)3, matrOfArray);

            InverseMatrix<double> Matr = new InverseMatrix<double>(A);

            Matrix<double> Inverse = Matr.Calculate();

            CollectionAssert.AreEqual(resultMatr, Inverse.Get2DArray());
        }
        [TestMethod]
        public void InverseUsersMatrixNumbDouble()
        {

            double[,] matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)3, matrOfArray);

            InverseMatrix<double> Matr = new InverseMatrix<double>(A);

            Matrix<double> inverse = Matr.Calculate();

            Assert.AreEqual(-1, inverse[0,0]);
        }

        [TestMethod]
        public void InverseExceptionDouble()
        {
            double[,] matrOfArray = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)3, matrOfArray);
            InverseMatrix<double> IM = new InverseMatrix<double>(A);

            bool Except = false;

            try
            {
                Matrix<double> M = IM.Calculate();
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

            double[,] MatrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            Matrix<double> C = new Matrix<double>((uint)4, (uint)3, MatrA);
            InverseMatrix<double> SM = new InverseMatrix<double>(A);

            SM.MatrixOperand = C;

            CollectionAssert.AreEqual(SM.MatrixOperand.Get2DArray(), C.Get2DArray());

        }

    }
}
