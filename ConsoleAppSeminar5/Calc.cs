using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSeminar5
{
    internal interface ICalc<T>
    {
        event EventHandler<EventArgs> GotResult;

        void ShowStartResult(T i);

        void Add(T i);

        void Sum(T value);

        void Substruct(T value);

        void Multiply(T value);

        void Divide(T value);     

        void CancelLast();

    }
}
