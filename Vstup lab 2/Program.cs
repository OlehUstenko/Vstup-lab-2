using System;

namespace Vstup_lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int choice;
            do
            {
                Console.WriteLine("" +
                    "\n1: Двійковий дріб --> Десятковий дріб" +
                    "\n2: Прямий код --> Додатковий код (32 біти)" +
                    "\n0: Вихід\n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (1):
                        Task1();
                        break;
                    case (2):
                        Task2();
                        break;
                    case (0):
                        Console.Write("Програму завершено, дякую за користування!");
                        break;
                }
            }
            while (choice != 0);
        }
        static void Task1()
        {
            Console.Write("Введіть дріб у двійковій системі: ");
            string temp = Console.ReadLine();
            string[] input = temp.Split('.',',');
            if (input[1].Length < 1)
            {
                Console.WriteLine("Після крапки нічого немає");
                return;
            }
            string afterDot = input[1];
            double result = 0;
            for (int i = 0; i < afterDot.Length; i++)
            {
                if (afterDot[i] == '1')
                {
                    result += Math.Pow(2, -(i + 1));
                }
            }
            Console.WriteLine($"Результат у десятковій системі: {result}");
        }
        static void Task2()
        {
            Console.WriteLine("Введіть прямий код (32 біти):");
            string input = Console.ReadLine();

            if (input.Length != 32)
            {
                Console.WriteLine("Помилка: довжина має бути 32 біти!");
                return;
            }

            char[] bits = input.ToCharArray();

            if (bits[0] == '1') 
            {
                bool foundFirstOne = false;
                for (int i = 31; i >= 1; i--)
                {
                    if (!foundFirstOne)
                    {
                        if (bits[i] == '1') foundFirstOne = true;
                    }
                    else
                    {
                        bits[i] = (bits[i] == '0' ? '1' : '0');
                    }
                }
            }
            Console.WriteLine("Додатковий код: " + new string(bits));
        }
    }
}
