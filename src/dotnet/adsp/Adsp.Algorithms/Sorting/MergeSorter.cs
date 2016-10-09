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
            var firstHalf = range.FirstHalf;
            var secondHalf = range.SecondHalf;

            if (range.Length > 1)
            {
                Sort(firstHalf);
                Sort(secondHalf);
            }

            MergeHalfs(firstHalf, secondHalf);
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

                if (_array[firstIndex] < _array[secondIndex])
                {
                    _target[targetIndex] = _array[firstIndex];
                    firstIndex++;
                }
                else
                {
                    _target[targetIndex] = _array[secondIndex];
                    secondIndex++;
                }

                targetIndex++;
            }
        }

        private void FlushRest(uint targetIndex, uint startIndex, uint endIndex)
        {
            for (var index = startIndex; index < endIndex; index++)
            {
                _target[targetIndex] = _array[index];
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
                Start = start;
                End = end;
                Length = End - Start;
                _oneHalfIndex = Length / 2;
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