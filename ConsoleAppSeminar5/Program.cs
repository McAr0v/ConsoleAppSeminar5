namespace ConsoleAppSeminar5
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs )
        {
            Console.WriteLine($"Текущий результат = {((Calculator)sendler).Result}");
        }


        // Функция считывания числа
        public static int? EnterValueInt(string text)
        {
            Console.Write(text);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            else
            {
                
                return null;
            }

            
        }

        // Функция считывания ввода действия
        public static string EnterValueString(string text)
        {
            Console.Write(text);
            string value = Console.ReadLine();

            return value;
        }


        static void Main(string[] args)
        {
            /* Доработайте программу калькулятор реализовав выбор действий 
             * и вывод результатов на экран в цикле так чтобы калькулятор 
             * мог работать до тех пор пока пользователь не нажмет отмена 
             * или введёт пустую строку.
            */

            ICalc calc = new Calculator();

            calc.GotResult += Calculator_GotResult;

            calc.ShowStartResult();

            bool Cancel = false;

            string InputAction = "";
            int? InputNumber = null;

            while (!Cancel)
            {
                InputAction = EnterValueString("Введите действие (+, -, /, *, back (для отмены последнего действия)): ");

                if (InputAction != "back" && InputAction != "") InputNumber = EnterValueInt("Введите число: ");

                if (InputAction == "" || InputNumber == null)
                {
                    Console.WriteLine("Программа завершена. Вы не ввели действие или число");
                    Cancel = true;
                    break;
                } else
                {

                    switch (InputAction)
                    {
                        case "*":
                            calc.Multiply((int)InputNumber);
                            break;
                        case "/":
                            calc.Divide((int)InputNumber);
                            break;
                        case "+":
                            calc.Sum((int)InputNumber);
                            break;

                        case "-":
                            calc.Substruct((int)InputNumber);
                            break;
                        case "back": calc.CancelLast(); break;

                        default: Console.WriteLine("Вы не правильно ввели действие. Попробуйте еще раз"); break;
                    }

                }
            }
        }
    }
}