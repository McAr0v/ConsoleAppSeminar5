namespace ConsoleAppSeminar5
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs )
        {
            Console.WriteLine($"Текущий результат = {Math.Round(((Calculator)sendler).Result, 2)}");
        }

        public static double? EnterValueDouble(string text)
        {
            Console.Write(text);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Введено не число.");
                return null;
            }
        }

        // Функция считывания ввода действия
        public static string EnterValueString(string text)
        {
            Console.Write(text);
            string value = Console.ReadLine();

            if (value == null) return "";
            else return value;
        }

       

        static void Main(string[] args)
        {
            /* Доработайте класс калькулятора способным работать как 
             * с целочисленными так и с дробными числами. 
             * (возможно стоит задействовать перегрузку операций).
            */

            ICalc<double> calc = new Calculator();

            calc.GotResult += Calculator_GotResult;

            calc.ShowStartResult(0);

            bool Cancel = false;

            string InputAction = "";
            double? InputNumber = null;
            

            while (!Cancel)
            {
                InputAction = EnterValueString("Введите действие (+, -, /, *, back (для отмены последнего действия)): ");

                if (InputAction != "back" && InputAction != "") InputNumber = EnterValueDouble("Введите число: ");

                if (InputAction == "" || InputNumber == null)
                {
                    Console.WriteLine("Программа завершена. Вы не ввели действие или число");
                    Cancel = true;
                    break;
                } else
                {
                    try 
                    {
                        switch (InputAction)
                        {
                            case "*":
                                calc.Multiply((double)InputNumber);
                                break;
                            case "/":
                                calc.Divide((double)InputNumber);
                                break;
                            case "+":
                                calc.Sum((double)InputNumber);
                                break;

                            case "-":
                                calc.Substruct((double)InputNumber);
                                break;
                            case "back": calc.CancelLast(); break;

                            default: Console.WriteLine("Вы не правильно ввели действие. Попробуйте еще раз"); break;
                        }

                    }
                    catch (CalculatorDivideByZeroException e)
                    { 
                    
                        Console.WriteLine($"{e}");

                    }

                    catch (CalculateOperationCauseOverflowException e)
                    {

                        Console.WriteLine($"{e}");

                    }

                }
            }
        }
    }
}