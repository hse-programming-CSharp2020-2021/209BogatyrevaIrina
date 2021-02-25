using System;

namespace _01
{
    struct Coords
    {
        double x, y;
        public Coords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"x = {x:f3}, y = {y:f3}";
        }
    }

    class Circle
    {
        Coords center;
        double radius;
        public (double, double) LengthAndSquare()
        {
            return (2 * Math.PI * radius, Math.PI * radius * radius);
        }
        public Coords Center
        {
            get { return center; }
            set { center = value; }
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                radius = value;
            }
        }

        public Circle(double x, double y, double radius)
        {
            center = new Coords(x, y);
            this.radius = radius;
        }

        public override string ToString()
        {
            (double length, double square) = LengthAndSquare();
            return $"центр: {center} радиус: {radius:f3} длина окр.: {length:f3} площадь: {square:f3}";
        }
    }

    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                Circle circle = new Circle(rand.NextDouble() * 5, rand.NextDouble() * 5, rand.NextDouble() * 5);
                Console.WriteLine(circle);
            }
        }
    }
}
