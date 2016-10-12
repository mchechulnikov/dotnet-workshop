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
        Assert.Equal(3, sortedArray[1]);
        Assert.Equal(22, sortedArray[2]);
        Assert.Equal(33, sortedArray[3]);
        Assert.Equal(42, sortedArray[4]);
        //Assert.Equal(46, sortedArray[5]);
        //Assert.Equal(7574, sortedArray[6]);
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
