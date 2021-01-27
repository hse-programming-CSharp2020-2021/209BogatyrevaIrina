using System;

namespace _01
{
    public delegate void CoordChanged(Dot dot);
    public class Dot
    {
        public event CoordChanged OnCoordChanged;
        double x, y;

        public Dot(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public void DotFlow()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                x = rand.NextDouble() * 20 - 10;
                y = rand.NextDouble() * 20 - 10;
                if (x < 0 && y < 0)
                    OnCoordChanged?.Invoke(this);
            }
        }

        public override string ToString() { return $"x = {x:f3}, y = {y:f3}"; }
    }

    class Program
    {
        static void PrintInfo(Dot A) { Console.WriteLine(A); }

        static void Main()
        {
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Dot D = new Dot(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}
