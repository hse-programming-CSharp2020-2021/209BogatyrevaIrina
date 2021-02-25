using System;

namespace _01
{
    interface ISequence { double GetElement(int index); }
    abstract class Progression
    {
        protected double first, step;
        public Progression(double first, double step)
        {
            this.first = first;
            this.step = step;
        }
        public abstract double GetElement(int index);
    }

    class ArithmeticalProgression : Progression, ISequence
    {
        public override double GetElement(int index) { return first + (index - 1) * step; }
        public ArithmeticalProgression(int first, int step) : base(first, step) { }
    }

    class GeometricProgression : Progression, ISequence
    {
        public override double GetElement(int index) { return first * (int)Math.Pow(step, index - 1); }
        public GeometricProgression(int first, int step) : base(first, step) { }
    }

    class Program
    {
        static double Sum(Progression prog, int index)
        {
            double res = 0;
            for (int i = 1; i <= index; i++)
                res += prog.GetElement(i);
            return res;
        }

        static void Main()
        {
            Console.WriteLine(Sum(new ArithmeticalProgression(3, 5), 5));
            Console.WriteLine(Sum(new GeometricProgression(3, 5), 3));
        }
    }
}
