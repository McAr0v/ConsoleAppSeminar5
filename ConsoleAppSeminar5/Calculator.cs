using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppSeminar5
{

    internal class Calculator : ICalc<double>
    {
        private Stack<double> Results = new Stack<double>();
        private Stack<CalcActionLog> actions = new Stack<CalcActionLog>();

        public event EventHandler<EventArgs> GotResult;

        public double Result = 0;

        public void ShowStartResult(double i)
        {
            Results.Push(i);
            RaiseEvent();
        }

        // Методы для работы с double
        public void Divide(double value)
        {
            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("Ошибка: Произошло деление на 0", actions);
            }

            Results.Push(Result);
            Result /= value;
            RaiseEvent();
        }

        public void Multiply(double value)
        {
            Results.Push(Result);
            Result *= value;
            RaiseEvent();
        }

        public void Substruct(double value)
        {
            Results.Push(Result);
            Result -= value;
            RaiseEvent();
        }

        public void Sum(double value)
        {
            Results.Push(Result);
            Result += value;
            RaiseEvent();
        }

        public void Add(double i)
        {
            Results.Push(Result);
            Result += i;
            RaiseEvent();
        }

        // Методы для работы с int
        public void Divide(int value)
        {
            Divide((double)value); 
        }

        public void Multiply(int value)
        {
            Multiply((double)value); 
        }

        public void Substruct(int value)
        {
            Substruct((double)value); 
        }

        public void Sum(int value)
        {
            Sum((double)value); 
        }

        public void Add(int i)
        {
            Add((double)i); 
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

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }


}
