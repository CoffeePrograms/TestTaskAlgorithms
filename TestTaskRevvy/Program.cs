using System.Numerics;
using System.Xml;
using TestTaskRevvy2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestTask2
{
    /*
     * Есть массив из n натуральных чисел,  n>=1. Написать функцию, которая определяет, можно ли заданное число представить суммой чисел из массива (каждое число можно использовать один раз).
     * Пример:
     * Массив: {3, 1, 8, 5, 4}
     * Число 10 - можно представить суммой (1+5+4)
     * Число 2 - нельзя
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 8, 5, 4 };
            int digit = 0;
            bool isDigit = false;

            Console.WriteLine("Массив: " + string.Join(',', arr));
            while (!isDigit)
            {
                Console.WriteLine("Введите число");
                isDigit = int.TryParse(Console.ReadLine(), out digit);
            }

            var res = CheckSumService.Check(arr, digit);
            if (res == null)
                Console.WriteLine("Нет решения");
            else
                Console.WriteLine(string.Join(',', res));
        }
    }
}