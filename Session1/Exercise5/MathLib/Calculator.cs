namespace MathLib
{
    public class Calculator
    {
        public static int Add(int x, int y) => (x + y);

        public static int Add(int[] ints)
        {
            int sum = 0;
            foreach (int num in ints)
                sum += num;
            return sum;
        }

        public static int Max(int x, int y) => x > y ? x : y;
    }
}