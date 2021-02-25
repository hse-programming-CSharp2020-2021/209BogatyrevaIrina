using System;
using System.Collections.Generic;

namespace _03
{
    struct Point
    {
        double x, y;
        public double X { get { return x; } }
        public double Y { get { return y; } }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x = {x:f3}, y = {y:f3}";
        }

        public double Distance(Point point)
        {
            return Math.Sqrt((x - point.x) * (x - point.x) + (y - point.y) * (y - point.y));
        }
    }

    class Multiplicity
    {
        List<Point> points = new List<Point>();
        double radius;
        public double Radius { get { return radius; } }

        public Point MassCenter()
        {
            if (points.Count == 0)
            {
                Console.WriteLine("Нет точек в круге");
                return new Point();
            }
            double allX = 0, allY = 0;
            foreach (Point point in points)
            {
                allX += point.X;
                allY += point.Y;
            }
            return new Point(allX / points.Count, allY / points.Count);
        }

        public Multiplicity(double r, List<Point> allPoints)
        {
            radius = r;
            foreach (Point point in allPoints)
                if (point.Distance(new Point()) <= radius)
                    points.Add(point);
        }

        public override string ToString()
        {
            string res = "Точки:\n";
            foreach (Point point in points)
                res += $"{point}\n";
            res += $"Центр масс: {MassCenter()}";
            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            List<Point> points = new List<Point>();
            Console.WriteLine("Все точки\n");
            for (int i = 0; i < 5; i++)
            {
                points.Add(new Point(rand.NextDouble() * 10, rand.NextDouble() * 10));
                Console.WriteLine(points[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                double rad = rand.NextDouble() * 20;
                Console.WriteLine($"\nКруг с радиусом {rad:f3}");
                Console.WriteLine(new Multiplicity(rad, points));
            }
        }
    }
}
