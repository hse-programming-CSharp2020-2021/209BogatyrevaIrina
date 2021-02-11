using System;
using System.Collections.Generic;

namespace _01
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            int n = Convert.ToInt32(Console.ReadLine());
            while (n != 0)
            {
                int i = n % 10;
                list.AddFirst(i);
                stack.Push(i);
                n /= 10;
            }
            foreach (int i in stack)
                Console.Write(i + " ");
            Console.WriteLine();
            foreach (int i in list)
                Console.Write(i + " ");
        }
    }
}