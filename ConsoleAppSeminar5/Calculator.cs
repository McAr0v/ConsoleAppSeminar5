using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSeminar5
{
    
    internal class Calculator : ICalc
    {

        private Stack<int> Results = new Stack<int>();

        public event EventHandler<EventArgs> GotResult;

        public int Result = 0;

        public void ShowStartResult()
        {
            Results.Push(Result);
            RaiseEvent();
        }

        public void Divide(int value)
        {
            
            if (value != 0)
            {
                Results.Push(Result);
                Result /= value;
                RaiseEvent();

            }
            
            
            
            
        }

        public void Multiply(int value)
        {
            Results.Push(Result);
            Result *= value;
            RaiseEvent();
            
        }

        public void Substruct(int value)
        {
            Results.Push(Result);
            Result -= value;
            RaiseEvent();
            
        }

        public void Sum(int value)
        {
            Results.Push(Result);
            Result += value;
            RaiseEvent();
        }

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void Add(int i)
        {
            throw new NotImplementedException();
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RaiseEvent();
            }
            else
            {
                Console.WriteLine("Нельзя дальше вернуть");
            }
            
        }
    }
}
