using System;

namespace _02
{
    using System;
    using System.Collections.Generic;

    namespace ConsoleApp3
    {
        struct Person
        {
            string name, surname;
            int age;
            public Person(string name, string surname, int age)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }
            public override string ToString()
            {
                return $"{name} {surname}, age {age}";
            }
        }

        class ElectronicQueue<T>
        {
            Queue<T> queue = new Queue<T>();
            public void Enqueue(T newOne) { queue.Enqueue(newOne); }
            public T Dequeue() { return queue.Dequeue(); }
            public int Size { get { return queue.Count; } }
        }


        class Program
        {
            static void Main()
            {
                Random rand = new Random();
                ElectronicQueue<Person> queue = new ElectronicQueue<Person>();
                for (int i = 0; i < 5; i++)
                    queue.Enqueue(new Person($"Name{i + 1}", $"Surname{i + 1}", rand.Next(100)));
                Console.WriteLine(queue.Size);
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Size);
            }
        }
    }
}
