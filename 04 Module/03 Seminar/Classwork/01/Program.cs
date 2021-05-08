using System;

namespace _01
{
    class State
    {
        public decimal Population { get; set; }
        public decimal Area { get; set; }
        public static State operator +(State state1, State state2)
        {
            return new State
            {
                Population = state1.Population + state2.Population,
                Area = state1.Area + state2.Area
            };
        }
        public static bool operator >(State state1, State state2)
        {
            return state1.Population > state2.Population && state1.Area > state2.Area;
        }

        public static bool operator <(State state1, State state2)
        {
            return state1.Population < state2.Population && state1.Area < state2.Area;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            State state1 = new State { Population = 10, Area = 5 };
            State state2 = new State { Population = 8, Area = 3 };
            Console.WriteLine(state1 > state2);
            Console.WriteLine(state1 < state2);
            State state3 = state1 + state2;
            Console.WriteLine(state3.Population + " " + state3.Area);
        }
    }
}


