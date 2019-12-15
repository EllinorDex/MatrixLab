using System;

namespace MatrixLib.Operations
{
    //Интерфейс операции, возвращающающей матрицу
    interface IOperationThatReturnMatrix<T> where T : IConvertible
    {
        Matrix<T> Calculate();
    }
}
