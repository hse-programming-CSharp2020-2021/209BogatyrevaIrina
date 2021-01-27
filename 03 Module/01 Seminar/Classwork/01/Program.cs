using System;
using static System.Console;

namespace _01
{
    class Program
    {
        delegate int Cast(double x);

        static void Test(Cast c)
        {
            WriteLine(c(9.2));
            WriteLine(c(10));
            WriteLine(c(10.2));
            WriteLine(c(11.2));
            WriteLine(c(121));
            WriteLine();
        }

        static void Main()
        {
            Cast c1 = delegate (double x) { return (int)x % 2 == 0 ? (int)x : (int)x + 1; };
            Cast c2 = delegate (double x)
            {
                int ans = 0;
                int intX = (int)x;
                while (intX > 0)
                {
                    intX /= 10;
                    ans++;
                }
                return ans;
            };

            Cast c3 = (double x) => (int)x % 2 == 0 ? (int)x : (int)x + 1;
            Cast c4 = (double x) =>
            {
                int ans = 0;
                int intX = (int)x;
                while (intX > 0)
                {
                    intX /= 10;
                    ans++;
                }
                return ans;
            };

            Cast c5 = c1;
            Test(c5);
            c5 += c2;
            Test(c5);
        }
    }
}
