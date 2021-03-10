using System;
using System.IO;

namespace _03
{
    class Program
    {
        static void Main()
        {
            Random rn = new Random();
            int[] integers = new int[10];
            for (int i = 0; i < integers.Length; i++)
                integers[i] = rn.Next(20);


            string path1 = @"..\..\..\test1.txt";
            foreach (int integer in integers)
                File.AppendAllText(path1, integer.ToString() + "\n");
            string[] test = File.ReadAllLines(path1);
            int sum = 0;
            foreach (string num in test)
            {
                Console.Write(num + " ");
                if (int.Parse(num) % 2 == 0)
                    sum += int.Parse(num);
            }
            Console.WriteLine($"sum = {sum}\n");
            File.Delete(path1);


            string path2 = @"..\..\..\test2.txt";
            using (FileStream fs = new FileStream(path2, FileMode.Create))
            {
                foreach (int integer in integers)
                    fs.Write(BitConverter.GetBytes(integer));
                sum = 0;
                fs.Position = 0;
                while (fs.Position != fs.Length)
                {
                    int integer = fs.ReadByte();
                    Console.Write(integer + " ");
                    if (integer % 2 == 0)
                        sum += integer;
                }
            }
            Console.WriteLine($"sum = {sum}\n");


            string path3 = @"..\..\..\test3.txt";
            using (StreamWriter sw = new StreamWriter(path3))
            {
                foreach (int integer in integers)
                    sw.WriteLine(integer);
            }
            sum = 0;
            using (StreamReader sr = new StreamReader(path3))
            {
                while (sr.Peek() != -1)
                {
                    int integer = Convert.ToInt32(sr.ReadLine());
                    Console.Write(integer + " ");
                    if (integer % 2 == 0)
                        sum += integer;
                }
            }
            Console.WriteLine($"sum = {sum}\n");


            string path4 = @"..\..\..\test4.txt";
            using (BinaryWriter bw = new BinaryWriter(new FileStream(path4, FileMode.Create)))
            {
                foreach (int integer in integers)
                    bw.Write(integer);
            }
            sum = 0;
            using (BinaryReader br = new BinaryReader(new FileStream(path4, FileMode.Open)))
            {
                while (br.PeekChar() != -1)
                {
                    int integer = br.ReadInt32();
                    Console.Write(integer + " ");
                    if (integer % 2 == 0)
                        sum += integer;
                }
            }
            Console.WriteLine($"sum = {sum}\n");
        }
    }
}
