using System;

namespace _02
{
    struct PointS
    {
        double x, y;
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Distance(PointS point)
        {
            return Math.Sqrt((x - point.x) * (x - point.x) + (y - point.y) * (y - point.y));
        }
        public PointS(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct CircleC : IComparable<CircleC>
    {
        double rad;
        PointS center;
        public double Rad
        {
            get { return rad; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                rad = value;
            }
        }
        public PointS Center { get { return center; } set { center = value; } }
        public double Length { get { return 2 * Math.PI * rad; } }
        public CircleC(double x, double y, double radius)
        {
            rad = radius;
            center = new PointS(x, y);
        }
        public override string ToString()
        {
            return $"центр: x = {center.X:f3}, y = {center.Y:f3}; радиус: {rad:f3}; длина окр.: {Length:f3}";
        }

        public int CompareTo(CircleC other)
        {
            return rad.CompareTo(other.rad);
        }
    }

    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            CircleC[] circles = new CircleC[5];
            Console.WriteLine("Неотсортированный массив\n");
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = new CircleC(rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 10);
                Console.WriteLine(circles[i]);
            }
            Array.Sort(circles);
            Console.WriteLine("\nОтсортированный массив\n");
            for (int i = 0; i < circles.Length; i++)
                Console.WriteLine(circles[i]);
        }
    }
}
