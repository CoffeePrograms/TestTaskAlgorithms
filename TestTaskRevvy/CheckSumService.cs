using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskRevvy2
{
    public static class CheckSumService
    {
        /// <summary>
        /// Возвращает список чисел 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<int>? Check(int[] arr, int target)
        {
            // в ключе possibleSums хранится сумма, в значении числа, дающие эту сумму
            Dictionary<int, List<int>> possibleSums = new();
            // записываем нуль, что было с чего суммировать
            possibleSums.Add(0, new List<int>());

            foreach (int num in arr)
            {
                Dictionary<int, List<int>> newSums = new();

                // формируем новые суммы с числом num
                foreach (KeyValuePair<int, List<int>> pair in possibleSums)
                {
                    List<int> newNums = new(pair.Value);
                    newNums.Add(num);

                    int newSum = pair.Key + num;
                    newSums.Add(newSum, newNums);

                    if (newSum == target)
                    {
                        return newNums;
                    }
                }

                // если нашли новые возможные суммы чисел, фиксируем их
                foreach (KeyValuePair<int, List<int>> pair in newSums)
                {
                    if (!possibleSums.ContainsKey(pair.Key))
                    {
                        possibleSums.Add(pair.Key, pair.Value);
                    }
                }
            }
            return null;
        }
    }
}
