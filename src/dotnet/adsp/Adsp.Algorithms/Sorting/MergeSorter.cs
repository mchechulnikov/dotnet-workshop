using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Adsp.Algorithms.Sorting
{
  public class MergeSorter
  {
    private readonly int[] _array;
    private readonly int[] _target;

    private MergeSorter(int[] array)
    {
      _array = array;
      _target = new int[array.Length];
    }

    public static int[] Sort(int[] array)
    {
      var sorter = new MergeSorter(array);
      sorter.StartSorting();

      return sorter._target;
    }

    private void StartSorting()
    {
      Sort(new Range(0, (uint) _array.Length - 1));
    }

    private void Sort(Range range)
    {
      if (range.Length == 1)
      {
        _target[range.Start] = _array[range.Start];
        return;
      }

      if (range.Length == 2)
      {
        SortPair(range);
        return;
      }

      var firstHalf = range.FirstHalf;
      var secondHalf = range.SecondHalf;

      Sort(firstHalf);
      Sort(secondHalf);

      MergeHalfs(firstHalf, secondHalf);
    }

    private void SortPair(Range range)
    {
      if (_array[range.Start] < _array[range.End])
      {
        _target[range.Start] = _array[range.Start];
        _target[range.End] = _array[range.End];
      }
      else
      {
        _target[range.Start] = _array[range.End];
        _target[range.End] = _array[range.Start];
      }
    }

    private void MergeHalfs(Range firstHalf, Range secondHalf)
    {
      var firstIndex = firstHalf.Start;
      var secondIndex = secondHalf.Start;
      var targetIndex = firstIndex;

      while (true)
      {
        if (firstIndex == firstHalf.End)
        {
          FlushRest(targetIndex, secondIndex, secondHalf.End);
          break;
        }
        if (secondIndex == secondHalf.End)
        {
          FlushRest(targetIndex, firstIndex, firstHalf.End);
          break;
        }

        if (_target[firstIndex] < _target[secondIndex])
        {
          _target[targetIndex] = _target[firstIndex];
          firstIndex++;
        }
        else
        {
          _target[targetIndex] = _target[secondIndex];
          secondIndex++;
        }

        targetIndex++;
      }
    }

    private void FlushRest(uint targetIndex, uint startIndex, uint endIndex)
    {
      for (var index = startIndex; index <= endIndex; index++)
      {
        _target[targetIndex] = _target[index];
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
