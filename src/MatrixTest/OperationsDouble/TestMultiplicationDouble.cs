using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestMultiplicationDouble
    {
        [TestMethod]
        public void MultiplicationZerosMatrixDouble()
        {
            double[,] resultMatr = new double[5, 3];
            Matrix<double> A = new Matrix<double>((uint)3, (uint)7, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)7, (uint)5, MatrixType.zeros);

            Multiplication<double> Mult = new Multiplication<double>(A, B);

            Matrix<double> C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void MultiplicationUsersMatrixDouble()
        {
            double[,] MatrA = new double[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } };
            double[,] MatrB = new double[,] { { 1, 3 }, { 2, 4 } };
            double[,] resultMatr = new double[,] { { 5, 11 }, { 14, 32 }, { 23, 53 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)2, MatrA);
            Matrix<double> B = new Matrix<double>((uint)2, (uint)2, MatrB);

            Multiplication<double> Mult = new Multiplication<double>(A, B);

            Matrix<double> C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        //Кирилл, в этом тесте же вроде не должно выкидываться исключение
        [TestMethod]
        public void MultMatrixExceptionDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)4, (uint)5, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)4, (uint)5, MatrixType.zeros);
            Multiplication<double> Mult = new Multiplication<double>(A, B);

            Assert.ThrowsException<MatrixException>(() => Mult.Calculate());
        }
    }
}
