using System;
using System.IO;

namespace _02
{
    class Program
    {
        static void Main()
        {
            using (FileStream fs = new FileStream(@"..\..\..\Program.cs", FileMode.Open))
            {
                int t;
                while ((t = fs.ReadByte()) != -1)
                    if (t >= '0' && t <= '9')
                        Console.WriteLine((char)t);
            }
        }
    }
}
