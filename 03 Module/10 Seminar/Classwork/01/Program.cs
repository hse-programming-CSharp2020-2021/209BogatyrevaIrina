﻿using System;
using System.IO;

namespace _01
{
    class Program
    {
        static void Main()
        {
            BinaryWriter fOut = new BinaryWriter(
            new FileStream("../../../t.dat", FileMode.Create));
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(i);
            fOut.Close();

            FileStream f = new FileStream("../../../t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            fIn.Close();
            f.Close();

            Console.WriteLine("\n***");
            Console.WriteLine("\nЧисла в обратном порядке:");
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    for (int offset = 4; offset <= reader.BaseStream.Length; offset += 4)
                    {
                        reader.BaseStream.Seek(-offset, SeekOrigin.End);
                        Console.Write(reader.ReadInt32() + " ");
                    }
                }
            }

            Console.WriteLine("\n***");
            Console.WriteLine("\nУвеличить числа в 5 раз:");
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    using (BinaryWriter writer = new BinaryWriter(fStream))
                    {
                        for (int i = 0; i < fStream.Length / 4; i++)
                        {
                            a = reader.ReadInt32() * 5;
                            writer.BaseStream.Seek(reader.BaseStream.Seek(-4, SeekOrigin.Current), SeekOrigin.Begin);
                            writer.Write(a);
                        }
                    }
                }
            }

            Console.WriteLine("\n***");
            Console.WriteLine("\nЧисла в прямом порядке:");
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    for (int i = 0; i < fStream.Length / 4; i++)
                    {
                        a = reader.ReadInt32();
                        Console.Write(a + " ");
                    }
                }
            }
        }
    }
}
