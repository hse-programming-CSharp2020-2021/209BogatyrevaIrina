using System;
using System.Linq;

namespace _01
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

            var squares1 = from num in numbers
                           select num * num;
            var squares2 = numbers.Select(n => n * n);

            var positive1 = from num in numbers
                            where 9 < num && num < 100
                            select num;
            var positive2 = numbers.Where(n => 9 < n && n < 100);

            var evens1 = from num in numbers
                         where num % 2 == 0
                         orderby num descending
                         select num;
            var evens2 = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);

            var order1 = from num in numbers
                         group num by Math.Abs(num).ToString().Length;
            var order2 = numbers.GroupBy(n => Math.Abs(n).ToString().Length);

            Console.WriteLine("All");
            Array.ForEach(numbers.ToArray(), Print);
            Console.WriteLine("\nSquares");
            Array.ForEach(squares1.ToArray(), Print);
            Console.WriteLine("\nPositives with length 2");
            Array.ForEach(positive1.ToArray(), Print);
            Console.WriteLine("\nEvens");
            Array.ForEach(evens1.ToArray(), Print);
            Console.WriteLine("\nBy length");
            foreach (var type in order2)
            {
                Console.WriteLine("\nLength: " + type.Key);
                Array.ForEach(type.ToArray(), Print);
            }
        }

        static void Print(int i)
        {
            Console.Write(i + " ");
        }
    }
}

