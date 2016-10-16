using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Adsp.Algorithms.Sorting
{
  public class QuickSorter
  {
    private readonly int[] _array;

    private QuickSorter(int[] array)
    {
      _array = array;
    }

    public static int[] Sort(int[] array)
    {
      var sorter = new QuickSorter(array);
      sorter.StartSorting();
      return sorter._array;
    }

    private void StartSorting()
    {
      Sort(new Range(0, (uint) _array.Length - 1));
    }

    private void Sort(Range range)
    {
      if (range.Length == 1) return;

      var partitioningIndex = Regularize(range);
      Sort(new Range(range.Start, partitioningIndex));
      Sort(new Range(partitioningIndex + 1, range.End));
    }

    private uint Regularize(Range range)
    {
      var leftIndex = range.Start;
      var rightIndex = range.End;
      var pivot = _array[range.OneHalfIndex];

      while (leftIndex != rightIndex)
      {
        while (_array[leftIndex] < pivot) leftIndex++;
        while (_array[rightIndex] > pivot) rightIndex--;
        if (leftIndex <= rightIndex) Swap(leftIndex, rightIndex);
      }
      return rightIndex;
    }

    private void Swap(uint sourceIndex, uint targetIndex)
    {
      var bubble = _array[targetIndex];
      _array[targetIndex] = _array[sourceIndex];
      _array[sourceIndex] = bubble;
    }

    private struct Range
    {
      public readonly uint Start;
      public readonly uint End;
      public readonly uint Length;
      public readonly uint OneHalfIndex;

      public Range(uint start, uint end)
      {
        if (start > end) throw new Exception("Invalid range");
        Start = start;
        End = end;
        Length = End - Start + 1;
        OneHalfIndex = start != end ? Start + (Length - 1) / 2 : 0;
      }
    }
  }
}
