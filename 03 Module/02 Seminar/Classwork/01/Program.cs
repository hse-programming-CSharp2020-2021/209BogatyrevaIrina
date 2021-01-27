using System;
using static System.Console;

namespace _01
{
    class Plant
    {
        double growth, photosensitivity, frostresistance;
        public Plant(double gr, double photo, double frost)
        {
            growth = gr;
            photosensitivity = photo;
            frostresistance = frost;
        }

        public double Growth
        {
            get { return growth; }
            set { growth = value; }
        }

        public double Photosensitivity
        {
            get { return photosensitivity; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException();
                photosensitivity = value;
            }
        }

        public double Frostresistance
        {
            get { return frostresistance; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException();
                frostresistance = value;
            }
        }

        public override string ToString()
        {
            return $"growth = {growth:f3}, " +
                $"photosensitivity = {photosensitivity:f3}, " +
                $"frostresistance = {frostresistance:f3}";
        }
    }

    class Program
    {
        static int Sorting(Plant x, Plant y)
        {
            if ((int)x.Photosensitivity % 2 == 0 && (int)y.Photosensitivity % 2 != 0)
                return -1;
            if ((int)x.Photosensitivity % 2 != 0 && (int)y.Photosensitivity % 2 == 0)
                return 1;
            return 0;
        }
        static void Main(string[] args)
        {
            Write("Input n: ");
            int n;
            try
            {
                n = Convert.ToInt32(ReadLine());
                if (n <= 0)
                    throw new Exception();
            }
            catch
            {
                WriteLine("Incorrect n");
                return;
            }

            Random rand = new Random();
            Plant[] arr = new Plant[n];
            for (int i = 0; i < n; i++)
                arr[i] = new Plant(rand.NextDouble() * 75 + 25,
                    rand.NextDouble() * 100, rand.NextDouble() * 80);

            WriteLine("\nИзначальный массив:");
            Array.ForEach(arr, a => WriteLine(a));

            WriteLine("\nПо убыванию роста:");
            Array.Sort(arr, delegate (Plant x, Plant y)
            {
                if (x.Growth > y.Growth) return -1;
                if (x.Growth < y.Growth) return 1;
                return 0;
            });
            Array.ForEach(arr, a => WriteLine(a));

            WriteLine("\nПо возрастанию морозоустойчивости:");
            Array.Sort(arr, (x, y) =>
            {
                if (x.Frostresistance > y.Frostresistance) return 1;
                if (x.Frostresistance < y.Frostresistance) return -1;
                return 0;
            });
            Array.ForEach(arr, a => WriteLine(a));

            WriteLine("\nПо четности светочувствительности:");
            Array.Sort(arr, (x, y) => Sorting(x, y));
            Array.ForEach(arr, a => WriteLine(a));

            WriteLine("\nИзмененная морозоустойчивость:");
            Array.ConvertAll(arr, x => {
                int frost = (int)x.Frostresistance;
                if (frost % 2 == 0)
                    x.Frostresistance /= 3;
                else
                    x.Frostresistance /= 2;
                return x;
            });
            Array.ForEach(arr, a => WriteLine(a));
            WriteLine();
        }
    }
}
