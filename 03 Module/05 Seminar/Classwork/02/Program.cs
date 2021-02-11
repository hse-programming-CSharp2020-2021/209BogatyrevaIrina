using System;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main()
        {
            Stack<char> stack = new Stack<char>();
            string str = Console.ReadLine();
            try
            {
                foreach (char ch in str)
                {
                    switch (ch)
                    {
                        case ')':
                            if (stack.Pop() != '(')
                                throw new Exception();
                            break;
                        case ']':
                            if (stack.Pop() != '[')
                                throw new Exception();
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                                throw new Exception();
                            break;
                        default:
                            stack.Push(ch);
                            break;
                    }
                }
                if (stack.Count != 0)
                    throw new Exception();
            }
            catch
            {
                Console.WriteLine("Wrong");
                return;
            }
            Console.WriteLine("Right");
        }
    }
}

