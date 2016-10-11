using System.Collections;
using Xunit;
using Xunit.Abstractions;
using Adsp.Algorithms.Sorting;

namespace Adsp.Algorithms.Tests.Sorting
{
    public class MergeSorterTests
    {
      [Fact]
      public void Sort_UnsortedArray_Valid()
      {
        var array = new [] { 42, 22, 46, 2, 33, 3, 7574 };
        var sortedArray = MergeSorter.Sort(array);

        Assert.Equal(2, sortedArray[0]);
      }

      [Fact]
      public void Sort_UnsortedArray_EqualLength()
      {
        var array = new [] { 42, 22, 46, 2, 33, 3, 7574 };
        var sortedArray = MergeSorter.Sort(array);
        Assert.Equal(array.Length, sortedArray.Length);
      }
    }
}
