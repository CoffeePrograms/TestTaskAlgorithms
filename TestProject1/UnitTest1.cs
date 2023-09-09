using System.Collections.Generic;
using TestTask1;

namespace TestProject1
{
    /// <summary>
    /// “есты провер€ют очередность "чиновников". 
    /// ѕример.
    ///     ¬ "1,[2]", "2,[3,4]" важно, чтобы 3 и 4 шли перед 2, а 2 перед 1. 
    ///     ѕри этом не имеет значени€ запишем мы в выходную последовательность 3,4 или 4,3. 
    /// </summary>
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new string[]{ "1,[2]", "3,[4]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 1));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 3));
        }
        [Fact]
        public void Test2()
        {
            var input = new string[] { "1,[2]", "2,[3,4]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 1));
            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 2));
        }

        [Fact]
        public void Test4()
        {
            var input = new string[] { "1,[2]", "2,[3,4]", "3,[5,7]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 1));
            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 5) < Array.IndexOf(res, 3));
            Assert.True(Array.IndexOf(res, 7) < Array.IndexOf(res, 3));
        }

        [Fact]
        public void Test5()
        {
            var input = new string[] { "3,[2,4]", "5,[3]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 3));
            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 3));
            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 5));
        }

        [Fact]
        public void Test6()
        {
            var input = new string[] { "5,[3]", "3,[2,4]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 5));
            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 3));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 3));
        }

        [Fact]
        public void Test7()
        {
            var input = new string[] { "2,[3,4]", "1,[2]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 1));
        }

        [Fact]
        public void Test8()
        {
            var input = new string[] { "2,[3,4]", "1,[2]", "3,[5,4]" };
            var res = SortService.ParseAndSort(input).ToArray();

            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 3) < Array.IndexOf(res, 2));
            Assert.True(Array.IndexOf(res, 2) < Array.IndexOf(res, 1));
            Assert.True(Array.IndexOf(res, 5) < Array.IndexOf(res, 3));
            Assert.True(Array.IndexOf(res, 4) < Array.IndexOf(res, 3));
        }

    }
}