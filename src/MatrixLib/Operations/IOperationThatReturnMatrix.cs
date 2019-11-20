using System;

namespace MatrixLib
{
    //Интерфейс операции, возвращающающей матрицу
    interface IOperationThatReturnMatrix<T> where T : IConvertible
    {
        Matrix<T> Calculate();
    }
}
