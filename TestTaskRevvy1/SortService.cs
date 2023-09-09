using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1
{
    public class SortService
    {
        public static IEnumerable<int> ParseAndSort(string[] input)
        {
            return Sort(Parse(input));
        }


        /// <summary>
        /// Парсит массив вида { "2,[3,4]", "1,[2]", "3,[5,4]" } в словарь, где ключ — число, значение — сет зависимых чисел.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        private static Dictionary<int, HashSet<int>> Parse(string[] input)
        {
            Dictionary<int, HashSet<int>> pairs = new();

            foreach (var item in input)
            {
                var parts = item.Split(',');

                var id = int.Parse(parts[0]);

                if (!pairs.ContainsKey(id))
                {
                    pairs.Add(id, new HashSet<int>());
                }

                for (int i = 1; i < parts.Length; i++)
                {
                    var childId = int.Parse(parts[i].TrimStart('[').TrimEnd(']'));

                    if (!pairs.ContainsKey(childId))
                    {
                        pairs.Add(childId, new HashSet<int>());
                    }

                    if (!pairs[id].Contains(childId))
                    {
                        pairs[id].Add(childId);
                    }
                }
            }
            return pairs;
        }

        /// <summary>
        /// Сортировка словаря с учетом зависимостей 
        /// </summary>
        /// <param name="pairs"></param>
        /// <returns></returns>
        private static IEnumerable<int> Sort(Dictionary<int, HashSet<int>> pairs)
        {
            HashSet<int> result = new();
            Stack<int> stack = new();

            foreach (var pair in pairs)
            {
                if (pair.Value.Count == 0)
                {
                    stack.Push(pair.Key);
                }
            }

            while (stack.Count != 0)
            {
                var key = stack.Pop();
                result.Add(key);

                pairs.Remove(key);

                foreach (var pair in pairs)
                {
                    var list = pair.Value;
                    foreach (var item in list)
                    {
                        if (item == key)
                        {
                            list.Remove(item);
                        }
                    }
                }

                foreach (var pair in pairs)
                {
                    if ((pair.Value.Count == 0) && (!stack.Contains(pair.Key)))
                    {
                        stack.Push(pair.Key);
                    }
                }
            }
            return result;
        }

    }
}
