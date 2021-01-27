using System;
using System.Text;
using static System.Console;

namespace _02
{
    delegate string ConvertRule(string str);

    class Converter
    {
        public string Convert(string str, ConvertRule cr)
        {
            return cr(str);
        }
    }

    class Program
    {
        public static string RemoveDigits(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i <= 9; i++)
                sb.Replace($"{i}", "");
            return sb.ToString();
        }

        public static string RemoveSpaces(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Replace(" ", "");
            return sb.ToString();
        }

        static void Main()
        {
            Converter conv = new Converter();
            string[] test = { "test 1test 4", "try   aga1n" };
            ConvertRule rule = RemoveDigits;
            WriteLine("RemoveDigits");
            foreach (string str in test)
                WriteLine(conv.Convert(str, rule));

            rule = RemoveSpaces;
            WriteLine("\nRemoveSpaces");
            foreach (string str in test)
                WriteLine(conv.Convert(str, rule));

            rule += RemoveDigits;
            WriteLine("\nRemoveSpaces + RemoveDigits");
            foreach (string str in test)
                WriteLine(conv.Convert(str, rule));

            rule = RemoveDigits;
            rule += RemoveSpaces;
            WriteLine("\nRemoveDigits + RemoveSpaces");
            foreach (string str in test)
                WriteLine(conv.Convert(str, rule));
        }
    }
}
