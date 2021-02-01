using System;

namespace Task_6
{
    public delegate void LineCompleteEvent();
    public delegate void GetSumEvent(int[,] arr);

    public class Methods
    {
        public static event LineCompleteEvent LineComplete;
        public static event GetSumEvent NewItemFilled;

        public static int[,] ArrayFill(int n)
        {
            int[,] arr = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rand.Next(100);
                    NewItemFilled?.Invoke(arr);
                }
            return arr;
        }

        public static void ArrayPrint(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    Console.Write($"{arr[i, j]} ");
                LineComplete?.Invoke();
            }
        }

        public static void ArraySumCount(int[,] arr)
        {
            int res = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    res += arr[i, j];
            Console.WriteLine(res);
        }
    }


    class Program
    {
        static void Main()
        {
            Methods.LineComplete += () => Console.WriteLine();
            Methods.NewItemFilled += Methods.ArraySumCount;
            int[,] arr = Methods.ArrayFill(5);
            Methods.ArrayPrint(arr);
        }
    }
}
