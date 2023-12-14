using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSeminar5
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;

        void ShowStartResult();

        void Add(int i);

        void Sum(int value);

        void Substruct(int value);

        void Multiply(int value);

        void Divide(int value);

        void CancelLast();

    }
}
