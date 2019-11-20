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

            bool Except = false;

            try
            {
                Matrix<double> M = Mult.Calculate();
            }
            catch (MatrixException)
            {
                Except = true;
            }

            Assert.IsTrue(Except);
        }

        [TestMethod]
        public void GetSetMultMatrixDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)4, (uint)5, MatrixType.zeros);
            Matrix<double> B = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            double[,] MatrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            Matrix<double> C = new Matrix<double>((uint)4, (uint)3, MatrA);
            Matrix<double> D = new Matrix<double>((uint)4, (uint)3, MatrA);
            Multiplication<double> SM = new Multiplication<double>(A, B);

            SM.MatrixLeft = C;
            //
            SM.MatrixRight = D;

            CollectionAssert.AreEqual(SM.MatrixLeft.Get2DArray(), C.Get2DArray());
            CollectionAssert.AreEqual(SM.MatrixRight.Get2DArray(), C.Get2DArray());

        }

    }
}
