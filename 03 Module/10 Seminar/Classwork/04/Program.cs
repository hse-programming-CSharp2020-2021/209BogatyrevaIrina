using System;
using System.IO;

namespace _04
{
    class Program
    {
        static int constant = 100;
        static void Main()
        {
            Random rand = new Random();
            using (StreamWriter sw = new StreamWriter(new FileStream("output.txt", FileMode.Create)))
            {
                Console.SetOut(sw);
                for (int i = 0; i < constant; i++)
                    Console.WriteLine(Math.Round(rand.NextDouble() * 900 + 100, 2));
            }

            double average = 0;
            using (StreamReader sr = new StreamReader(new FileStream("output.txt", FileMode.Open)))
            {
                Console.SetIn(sr);
                for (int i = 0; i < constant; i++)
                    average += double.Parse(Console.ReadLine());
            }
            StreamWriter sw2 = new StreamWriter(Console.OpenStandardOutput());
            sw2.AutoFlush = true;
            Console.SetOut(sw2);
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.WriteLine(Math.Round(average / constant, 2));
        }
    }
}
