namespace Tasks
{
    public class MaxDiff
    {
        public static int Calc(int[] a)
        {
            var maxDiff = -1;
            var max = a[a.Length - 1];
            for (var i = a.Length - 2; i >= 0; i--)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
                else
                {
                    var diff = max - a[i];
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }
            }
            return maxDiff;
        }
    }
}
