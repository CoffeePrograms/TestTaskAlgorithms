using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace TestTask1
{
    /*
     * Есть N чиновников, каждый из которых выдает справку определенного вида. 
     * Кроме того, у каждого чиновника есть набор справок, которые нужно получить до того, 
     * как обратиться к нему за справкой. 
     * Запрограммировать алгоритм, по которому можно получить все справки. 
     * Обойтись без рекурсии.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "2,[3,4]", "1,[2]", "3,[5,4]" };
            
            Console.WriteLine(string.Join(',', SortService.ParseAndSort(input)));

            Console.ReadLine();
        }
    }
}