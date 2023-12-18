using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSeminar5
{
    internal class CalculatorException: Exception
    {
        public CalculatorException(string message, Stack<CalcActionLog> actionLogs) : base(message)
        {
            ActionLogs = actionLogs;
        }

        public override string ToString()
        {
            return Message + ":" + string.Join("\n", ActionLogs.Select(x => $"{x.CalcAction}{x.CalcArgument}"));
        }

        public CalculatorException(string message, Exception e) : base(message, e)
        {

        }

        public Stack<CalcActionLog> ActionLogs { get; private set; }

    }

    internal class CalculatorDivideByZeroException : CalculatorException
    {
        public CalculatorDivideByZeroException(string message, Stack<CalcActionLog> actionLogs) : base (message, actionLogs)
        {
            
        }

        public CalculatorDivideByZeroException(string message, Exception e) : base(message, e)
        {

        }

        

    }

    internal class CalculateOperationCauseOverflowException: CalculatorException
    {
        public CalculateOperationCauseOverflowException(string message, Stack<CalcActionLog> actionLogs) : base(message, actionLogs)
        {

        }

        public CalculateOperationCauseOverflowException(string message, Exception e) : base(message, e)
        {

        }
    }


}
