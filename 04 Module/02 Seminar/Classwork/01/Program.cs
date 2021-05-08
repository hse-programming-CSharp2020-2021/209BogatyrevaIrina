using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace _01
{
    [Serializable]
    [XmlInclude(typeof(ColorConsoleSymbol))]
    public class ConsoleSymbol
    {
        readonly char symb;
        readonly int x, y;
        public char Symb { get { return symb; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public ConsoleSymbol(char symb, int x, int y)
        {
            this.symb = symb;
            this.x = x;
            this.y = y;
        }
        public ConsoleSymbol() { }
        public override string ToString()
        {
            return $"{symb}  (X, Y) = ({x}, {y})";
        }
    }

    [Serializable]
    public class ColorConsoleSymbol : ConsoleSymbol
    {
        readonly Color color;
        public Color Color { get { return color; } }
        public ColorConsoleSymbol(char symb, int x, int y, Color color) : base(symb, x, y)
        {
            this.color = color;
        }
        public ColorConsoleSymbol() { }
        public override string ToString()
        {
            return base.ToString() + $" Color = {color}";
        }
    }

    class Program
    {
        public static void Main()
        {
            List<ConsoleSymbol> allSymbols = CreateSymbols();
            allSymbols.ForEach(WriteLine);
            WriteLine("\nXML Serialization\n");
            XmlSerialize(allSymbols);
            WriteLine("\nBinary Serialization\n");
            BinarySerialize(allSymbols);
        }

        public static List<ConsoleSymbol> CreateSymbols()
        {
            List<Color> colors = new List<Color>
                {Color.White, Color.Red, Color.Green, Color.Yellow, Color.Blue, Color.Black};
            List<ConsoleSymbol> allSymbols = new List<ConsoleSymbol>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                char symb = (char)rand.Next(33, 150);
                int x = rand.Next(1000), y = rand.Next(1000);
                if (rand.Next(2) == 0)
                    allSymbols.Add(new ConsoleSymbol(symb, x, y));
                else
                    allSymbols.Add(new ColorConsoleSymbol(symb, x, y, colors[rand.Next(colors.Count)]));
            }
            return allSymbols;
        }

        public static void XmlSerialize(List<ConsoleSymbol> allSymbols)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ConsoleSymbol>));
            using (FileStream fs = new FileStream("Test.xml", FileMode.Create))
            {
                serializer.Serialize(fs, allSymbols);
            }

            using (FileStream fs = new FileStream("Test.xml", FileMode.Open))
            {
                List<ConsoleSymbol> newSymbols = (List<ConsoleSymbol>)serializer.Deserialize(fs);
                newSymbols.ForEach(WriteLine);
            }
        }

        public static void BinarySerialize(List<ConsoleSymbol> allSymbols)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Test.bin", FileMode.Create))
            {
                formatter.Serialize(fs, allSymbols);
            }

            using (FileStream fs = new FileStream("Test.bin", FileMode.Open))
            {
                List<ConsoleSymbol> newSymbols = (List<ConsoleSymbol>)formatter.Deserialize(fs);
                newSymbols.ForEach(WriteLine);
            }
        }
    }
}
