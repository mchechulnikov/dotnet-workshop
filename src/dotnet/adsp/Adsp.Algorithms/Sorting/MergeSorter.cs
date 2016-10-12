using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Adsp.Algorithms.Sorting
{
  public class MergeSorter
  {
    private readonly int[] _array;

    private MergeSorter(int[] array)
    {
      _array = array;
    }

    public static int[] Sort(int[] array)
    {
      var sorter = new MergeSorter(array);
      return sorter.StartSorting();
    }

    private int[] StartSorting()
    {
      return Sort(new Range(0, (uint) _array.Length - 1));
    }

    private int[] Sort(Range range)
    {
      if (range.Length == 1)
      {
        return new int[] { _array[range.Start] };
      }

      if (range.Length == 2)
      {
        return SortPair(range);
      }

      var firstHalfRange = range.FirstHalf;
      var secondHalfRange = range.SecondHalf;

      var firstHalf = Sort(firstHalfRange);
      var secondHalf = Sort(secondHalfRange);

      return MergeHalfs(firstHalf, secondHalf);
    }

    private int[] SortPair(Range range)
    {
      var result = new int[2];
      if (_array[range.Start] < _array[range.End])
      {
        result[0] = _array[range.Start];
        result[1] = _array[range.End];
      }
      else
      {
        result[0] = _array[range.End];
        result[1] = _array[range.Start];
      }
      return result;
    }

    private int[] MergeHalfs(int[] firstHalf, int[] secondHalf)
    {
      var result = new int[firstHalf.Length + secondHalf.Length];

      uint firstIndex = 0;
      uint secondIndex = 0;
      uint targetIndex = firstIndex;

      while (true)
      {
        if (firstIndex == firstHalf.Length)
        {
          FlushRest(targetIndex, secondIndex, secondHalf, ref result);
          break;
        }
        if (secondIndex == secondHalf.Length)
        {
          FlushRest(targetIndex, firstIndex, firstHalf, ref result);
          break;
        }

        if (firstHalf[firstIndex] < secondHalf[secondIndex])
        {
          result[targetIndex] = firstHalf[firstIndex];
          firstIndex++;
        }
        else
        {
          result[targetIndex] = secondHalf[secondIndex];
          secondIndex++;
        }

        targetIndex++;
      }
      return result;
    }

    private void FlushRest(uint targetIndex, uint startIndex, int[] source, ref int[] target)
    {
      for (var index = startIndex; index < source.Length; index++)
      {
        target[targetIndex] = source[index];
        targetIndex++;
      }
    }

    private struct Range
    {
      private readonly uint _oneHalfIndex;

      public readonly uint Start;
      public readonly uint End;
      public readonly uint Length;

      public Range(uint start, uint end)
      {
        if (start > end) throw new Exception();
        Start = start;
        End = end;
        Length = End - Start + 1;
        _oneHalfIndex = start != end ? Start + (Length - 1) / 2 : 0;
      }

      public Range FirstHalf
      {
        get { return new Range(Start, _oneHalfIndex); }
      }

      public Range SecondHalf
      {
        get { return new Range(_oneHalfIndex + 1, End); }
      }
    }
  }
}
