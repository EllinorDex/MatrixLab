using System;

namespace MatrixLib
{
    //Интерфейс операции, возвращающающей скаляр
    interface IOperationThatReturnScalar<T> where T: IConvertible
    {
        T Calculate();
    }
}
