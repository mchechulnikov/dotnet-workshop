using Xunit;

namespace Tasks.Tests
{
    public class MaxDiffTests
    {
        [Fact]
        public void Calc_AscOrdered_DiffBetweenFirstAndLast()
        {
            var result = MaxDiff.Calc(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            Assert.Equal(9, result);
        }

        [Fact]
        public void Calc_DescOrdered_NoMaxDiff()
        {
            var result = MaxDiff.Calc(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1});
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Calc_PartialAscOrdered1_Expected()
        {
            var result = MaxDiff.Calc(new[] { 4, 1, 2, 3 });
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calc_PartialAscOrdered2_Expected()
        {
            var result = MaxDiff.Calc(new[] { 3, 4, 6, 1, 2, 5 });
            Assert.Equal(4, result);
        }

        [Fact]
        public void Calc_PartialAscOrdered3_Expected()
        {
            var result = MaxDiff.Calc(new[] { 5, 7, 1, 6 });
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calc_OneElement_Expected()
        {
            var result = MaxDiff.Calc(new[] { 5 });
            Assert.Equal(-1, result);
        }
    }
}