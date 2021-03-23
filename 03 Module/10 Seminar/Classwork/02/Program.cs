using System;
using System.IO;

namespace _02
{
    class Program
    {
        static int cnst = 10;
        static void Main()
        {
            Random rand = new Random();
            using (BinaryWriter fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Create)))
            {
                for (int i = 0; i < cnst; i++)
                    fOut.Write(rand.Next(1, 101));
            }

            int[] arr = new int[cnst];
            using (BinaryReader reader = new BinaryReader(new FileStream("../../../t.dat", FileMode.Open)))
            {
                for (int i = 0; i < cnst; i++)
                {
                    int j = reader.ReadInt32();
                    arr[i] = j;
                    Console.Write(j + " ");
                }
            }

            Console.WriteLine();
            int input = Convert.ToInt32(Console.ReadLine());
            if (input < 1 || input > 100)
                return;
            int res = arr[0];
            foreach (int i in arr)
                if (Math.Abs(input - i) < Math.Abs(input - res))
                    res = i;
            Console.WriteLine(res);

            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    using (BinaryWriter writer = new BinaryWriter(fStream))
                    {
                        for (int i = 0; i < fStream.Length / 4; i++)
                        {
                            int a = reader.ReadInt32();
                            if (a == res)
                            {
                                writer.BaseStream.Seek(reader.BaseStream.Seek(-4, SeekOrigin.Current), SeekOrigin.Begin);
                                writer.Write(input);
                            }
                        }
                    }
                }
            }

            using (BinaryReader reader = new BinaryReader(new FileStream("../../../t.dat", FileMode.Open)))
            {
                for (int i = 0; i < cnst; i++)
                    Console.Write(reader.ReadInt32() + " ");
            }
        }
    }
}
