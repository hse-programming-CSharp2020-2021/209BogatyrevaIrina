using System;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            int N = int.Parse(Console.ReadLine());
            int[] numbers = new int[N];
            for (int i = 0; i < N; i++)
                numbers[i] = rand.Next(-1000, 1001);

            var sevens = numbers.Where(num => num.ToString()[num.ToString().Length - 1] == '7');

            var evens = numbers.Where(num => num % 2 == 0).OrderByDescending(num => num);

            var lastNums = numbers.Select(num => num.ToString()[num.ToString().Length - 1]);

            var evenOrOdd = numbers.GroupBy(num => Math.Abs(num % 2));

            Console.WriteLine("All");
            Array.ForEach(numbers.ToArray(), Print);
            Console.WriteLine("\nSevens");
            Array.ForEach(sevens.ToArray(), Print);
            Console.WriteLine("\nEvens");
            Array.ForEach(evens.ToArray(), Print);
            Console.WriteLine("\nLast numbers");
            Array.ForEach(lastNums.ToArray(), Print);
            Console.WriteLine("\nEven or odd");
            foreach (var t in evenOrOdd)
            {
                Console.WriteLine();
                Array.ForEach(t.ToArray(), Print);
            }
        }

        static void Print<T>(T i)
        {
            Console.Write(i + " ");
        }
    }
}

