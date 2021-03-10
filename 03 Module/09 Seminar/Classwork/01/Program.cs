using System;
using System.Collections.Generic;
using System.IO;

namespace _01
{
    class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta",
            "DarkSeaGreen", "Lime", "Purple", "DarkGreen", "DarkOrange", "Black",
            "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}";
            return string.Format(format, x, y, color);
        }
    }

    class Program
    {
        static Random gen = new Random();
        public static void Main()
        {
            string path = @"..\..\..\..\MyTest.txt";
            int N = 3; // Количество создаваемых объектов (число строк в файле)
                       //  TODO: Определить значение N 
            List<ColorPoint> list = new List<ColorPoint>();
            ColorPoint one;
            for (int i = 0; i < N; i++)
            {
                one = new ColorPoint();
                one.x = gen.NextDouble();
                one.y = gen.NextDouble();
                int j = gen.Next(0, ColorPoint.colors.Length);
                one.color = ColorPoint.colors[j];
                list.Add(one);
            }
            string[] arrData = Array.ConvertAll(list.ToArray(),
                         (ColorPoint cp) => cp.ToString());
            // Запись массива стpок в текстовый файл:   
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                foreach (string arr in arrData)
                {
                    foreach (char ch in arr)
                    {
                        byte[] bytes = BitConverter.GetBytes(ch);
                        fs.Write(bytes);
                    }
                }
            }
            Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}", N, path);
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(bytes);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
    }
}
