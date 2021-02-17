using System;

namespace _02
{
    interface ICalculation { double Perform(double x); }
    abstract class BaseOperation
    {
        protected double k;
        public BaseOperation(double k) { this.k = k; }
        public abstract double Perform(double x);
    }

    class Add : BaseOperation, ICalculation
    {
        public Add(double add) : base(add) { }
        public override double Perform(double x) { return x + k; }
    }

    class Multiply : BaseOperation, ICalculation
    {
        public Multiply(double mult) : base(mult) { }
        public override double Perform(double x) { return x * k; }
    }

    class Program
    {
        static double Calculate(double start, BaseOperation operation1, BaseOperation operation2)
        {
            return operation2.Perform(operation1.Perform(start));
        }
        static void Main()
        {
            Console.WriteLine(Calculate(1, new Add(2), new Multiply(3)));
        }
    }
}
