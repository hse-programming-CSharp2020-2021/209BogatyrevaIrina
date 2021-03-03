using System;

namespace _01
{
    interface IFigure { double Area { get; } }
    class Figure : IFigure
    {
        protected double info;
        public Figure(double info) { this.info = info; }
        public virtual double Area { get; }
    }
    class Square : Figure
    {
        public Square(double side) : base(side) { }
        public override double Area { get { return info * info; } }
        public override string ToString()
        {
            return $"Square, area = {Area:f3}";
        }
    }

    class Round : Figure
    {
        public Round(double side) : base(side) { }
        public override double Area { get { return Math.PI * info * info; } }
        public override string ToString()
        {
            return $"Round, area = {Area:f3}";
        }
    }

    class Program
    {
        static void Print<T>(T[] array, double lowerBorder) where T : IFigure
        {
            foreach (T figure in array)
                if (figure.Area > lowerBorder)
                    Console.WriteLine(figure);
        }
        static void Main()
        {
            Random rand = new Random();
            double lowerBorder = rand.NextDouble() * 10;
            Figure[] array = new Figure[5];
            for (int i = 0; i < array.Length; i++)
            {
                if (rand.Next(2) == 0)
                    array[i] = new Square(rand.NextDouble() * 5);
                else
                    array[i] = new Round(rand.NextDouble() * 5);
            }
            Console.WriteLine("Все фигуры\n");
            Print(array, 0);
            Console.WriteLine($"\nФигуры с площадью больше {lowerBorder:f3}\n");
            Print(array, lowerBorder);
        }
    }
}
