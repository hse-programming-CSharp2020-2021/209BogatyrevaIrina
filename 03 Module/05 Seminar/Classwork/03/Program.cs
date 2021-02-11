using System;
using System.Collections.Generic;

namespace _03
{
    public class Passenger
    {
        string name, surname;
        int age;
        public string Name { get { return name; } private set { name = value; } }
        public string Surname { get { return surname; } private set { surname = value; } }
        public bool IsOld { get { if (age > 65) return true; return false; } }
        public override string ToString() { return $"{name} {surname} Age: {age}"; }
        public Passenger(string name, string surname, int age)
        {
            if (age > 150)
                throw new ArgumentException("Wrong age");
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }

    public class PassengerWithChildren : Passenger
    {
        int children;
        public int Children
        {
            get { return children; }
            private set
            {
                if (value < 1 || value > 40)
                    throw new ArgumentException("Wrong number of children");
                children = value;
            }
        }
        public bool IsNewBorn { get; private set; }
        public override string ToString()
        { return base.ToString() + $" Children: {children} WithNewBorn: {IsNewBorn}"; }
        public PassengerWithChildren(string name, string surname, int age, int children, int newBorn)
            : base(name, surname, age)
        {
            this.children = children;
            if (newBorn == 0)
                IsNewBorn = false;
            else
                IsNewBorn = true;
        }
    }

    public class PassengerQueue
    {
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.IsOld || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn)
                priorityQueue.Enqueue(newPassenger);
            else
                ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            Console.WriteLine($"{priorityQueue.Count} passengers in priority queue");
            while (priorityQueue.Count > 3)
                Console.WriteLine($"Passenger {priorityQueue.Dequeue()} [priority] was serviced");
            while (priorityQueue.Count > 0 || ordinaryQueue.Count > 0)
            {
                if (priorityQueue.Count > 0)
                    Console.WriteLine($"Passenger {priorityQueue.Dequeue()} [priority] was serviced");
                if (ordinaryQueue.Count > 0)
                    Console.WriteLine($"Passenger {ordinaryQueue.Dequeue()} was serviced");
            }
        }
    }

    class Program
    {
        public static Random rand = new Random();
        static void Main()
        {
            PassengerQueue queue = new PassengerQueue();
            for (int i = 1; i < 11; i++)
            {
                Passenger passenger;
                if (rand.Next(2) == 0)
                    passenger = new Passenger($"Name{i}", $"Surname{i}", rand.Next(100));
                else
                    passenger = new PassengerWithChildren($"Name{i}", $"Surname{i}", rand.Next(100), rand.Next(40), rand.Next(2));
                queue.AddToQueue(passenger);
            }
            queue.StartServingQueue();
        }
    }
}

