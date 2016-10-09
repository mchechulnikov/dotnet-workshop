using Xunit;
using Adsp.Algorithms.Sorting;

namespace Adsp.Algorithms.Tests.Sorting
{
    public class MergeSorterTests
    {
        [Fact]
        public void Sort_Valid()
        {
            var array = new [] { 42, 22, 46, 2, 33, 3, 7574 };
            var sortedArray = MergeSorter.Sort(array);

            foreach (var item in sortedArray)
            {
                Assert.True(array.Contains(item));
            }
        }
    }
}