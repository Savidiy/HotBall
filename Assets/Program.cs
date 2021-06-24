using System;

namespace HotBall
{
    class Program
    {
        private const string STOP_STRING = "q";

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте. Вас приветствует математическая программа.");
            Console.WriteLine("Пожалуйста, введите число:");

            String inputText = Console.ReadLine();

            if (inputText == STOP_STRING)
                return;

            if (!Int32.TryParse(inputText, out int number))
                return;

            int factorial = 1;
            int sum = 0;
            int maxEvenNumber = 0;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
                sum += i;
                if (i % 2 == 0)
                {
                    maxEvenNumber = i;
                }
            }

            Console.WriteLine($"Факториал равен {factorial}");
            Console.WriteLine($"Сумма от 1 до {number} равна {sum}");
            Console.WriteLine($"Максимальное четное число меньше {number} равно {maxEvenNumber}");

            Console.ReadLine();
        }
    }
}