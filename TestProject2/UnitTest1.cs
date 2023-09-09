using static System.Runtime.InteropServices.JavaScript.JSType;
using TestTaskRevvy2;

namespace TestProject2
{
    /// <summary>
    /// Тесты проверяют наличие или отсутствие чисел, из которых можно сложить целевое число
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] arr = { 3, 1, 8, 5, 4 };
            var res = CheckSumService.Check(arr, 10);
            Assert.NotNull(res);
        }        

        [Fact]
        public void Test2()
        {
            int[] arr = { 3, 1, 8, 5, 4 };
            var res = CheckSumService.Check(arr, 2);
            Assert.Null(res);
        }

        [Fact]
        public void Test3()
        {
            int[] arr = { 3, 1, 8, 5, 4 };
            var res = CheckSumService.Check(arr, 3);
            Assert.NotNull(res);
        }

        [Fact]
        public void Test4()
        {
            int[] arr = { 3, 1, 8, 5, 4 };
            var res = CheckSumService.Check(arr, 21);
            Assert.NotNull(res);
        }
    }
}