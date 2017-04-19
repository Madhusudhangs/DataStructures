namespace SortingAlgorithms.Quicksort
{
    public class Quicksort
    {
        public static void Sort(int[] input, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(input, p, r);
                //int q = (p + r) / 2;

                System.Console.WriteLine("{0} = Sort(input,{1},{2})", q, p, r);

                //if (q > 1)
                Sort(input, p, q - 1);

                //if (q + 1 < r)
                Sort(input, q + 1, r);
            }
        }

        private static int Partition(int[] input, int p, int r)
        {
            int i = p - 1;
            int x = input[r];

            System.Console.WriteLine("Partition from {0} to {1}", p, r - 1);
            for (int j = p; j <= r - 1; j++)
            {
                if (input[j] <= x)
                {
                    i++;
                    Swap(input, i, j);
                }
            }

            Swap(input, i + 1, r);

            return i + 1;
        }

        private static void Swap(int[] input, int index1, int index2)
        {
            int temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }

        #region Test Case

        public static void TestCaseSort()
        {
            int[] input = new int[12] { 13, 19, 9, 5, 12, 8, 7, 4, 21, 11, 6, 2 };
            System.Console.WriteLine("Before");
            input.Display();

            Quicksort.Sort(input, 0, input.Length - 1);

            System.Console.WriteLine("------------------");
            System.Console.WriteLine("After");
            input.Display();
        }

        public static void SortWhenLastElementAsPivot()
        {
            int[] input = new int[12] { 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 21 };

            System.Console.WriteLine("Before");
            input.Display();

            Quicksort.Sort(input, 0, input.Length - 1);

            System.Console.WriteLine("------------------");
            System.Console.WriteLine("After");
            input.Display();
        }

        public static void SortWhenAllElementsAreSame()
        {
            int[] input = new int[10] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 };

            System.Console.WriteLine("Before");
            input.Display();

            Quicksort.Sort(input, 0, input.Length - 1);

            System.Console.WriteLine("------------------");
            System.Console.WriteLine("After");
            input.Display();
        }

        #endregion
    }
}
