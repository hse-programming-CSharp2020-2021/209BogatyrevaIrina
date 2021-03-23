using System;
using System.IO;

namespace _03
{
    struct Rectangle : IComparable<Rectangle>
    {
        public readonly int a, b;
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int CompareTo(Rectangle other)
        {
            if (a * b > other.a * other.b)
                return 1;
            if (a * b < other.a * other.b)
                return -1;
            return 0;
        }
    }

    class Block3D : IComparable<Block3D>
    {
        public readonly int height;
        public readonly Rectangle basis;
        public Block3D(int height, Rectangle basis)
        {
            this.height = height;
            this.basis = basis;
        }

        public int CompareTo(Block3D other)
        {
            return basis.CompareTo(other.basis);
        }

        public override string ToString()
        {
            return $"height: {height}; a = {basis.a}; b = {basis.b}; area = {basis.a * basis.b}";
        }
    }

    class Program
    {
        static int constant = 10;
        static void Main()
        {
            Random rand = new Random();
            Block3D[] blocks = new Block3D[constant];
            for (int i = 0; i < constant; i++)
                blocks[i] = new Block3D(rand.Next(1, 5), new Rectangle(rand.Next(1, 10), rand.Next(1, 10)));
            Array.Sort(blocks);
            foreach (Block3D block in blocks)
                Console.WriteLine(block);

            using (StreamWriter writer = new StreamWriter(new FileStream("../../../t.dat", FileMode.Create)))
            {
                foreach (Block3D block in blocks)
                    writer.WriteLine($"{block.height} {block.basis.a} {block.basis.b}");
            }

            Block3D[] newBlocks = new Block3D[constant];
            using (StreamReader reader = new StreamReader(new FileStream("../../../t.dat", FileMode.Open)))
            {
                for (int i = 0; i < constant; i++)
                {
                    string[] str = reader.ReadLine().Split();
                    newBlocks[i] = new Block3D(int.Parse(str[0]), new Rectangle(int.Parse(str[1]), int.Parse(str[2])));
                }
            }

            Console.WriteLine("\n***\n");
            foreach (Block3D block in newBlocks)
                Console.WriteLine(block);
        }
    }
}
