using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestDeteminantDouble
    {
        [TestMethod]
        public void DeteminantOnesMatrix()
        {
            
            Matrix<double> A = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            Determinant<double> Matr = new Determinant<double>(A);

            double detem = Matr.Calculate();

            Assert.AreEqual(1, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrix0()
        {
            double[,] matrOfArray = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)3, matrOfArray);

            Determinant<double> Matr = new Determinant<double>(A);

            double detem = Matr.Calculate();

            Assert.AreEqual(0, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrixNumb()
        {
            double[,] matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<double> A = new Matrix<double>((uint)3, (uint)3, matrOfArray);

            Determinant<double> Matr = new Determinant<double>(A);

            double detem = Matr.Calculate();

            Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void DeteminantException()
        {
            double[,] matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };
            Matrix<double> A = new Matrix<double>((uint)4, (uint)3, matrOfArray);

            Determinant<double> DM = new Determinant<double>(A);

            Assert.ThrowsException<MatrixException>(() => DM.Calculate());
        }
    }
}
