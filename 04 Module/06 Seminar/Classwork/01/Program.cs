using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    interface IVocal { void DoSound(); }

    public abstract class Animal : IVocal
    {
        static int ID = 1;
        int Id { get; }
        string Name { get; }
        public bool IsTakenCare { get; }
        public virtual void DoSound() { Console.WriteLine("Bip"); }
        public Animal(string name, bool isTakenCare)
        {
            Id = ID++;
            Name = name;
            IsTakenCare = isTakenCare;
        }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} IsTakenCare: {IsTakenCare}";
        }
    }

    public class Mammal : Animal
    {
        int Paws { get; }
        public Mammal(string name, bool isTakenCare, int paws) : base(name, isTakenCare)
        {
            Paws = paws;
        }
        public override string ToString()
        {
            return base.ToString() + $" Paws: {Paws}";
        }
        public override void DoSound()
        {
            Console.WriteLine("я млекопитающие, би-би-би");
        }
    }

    public class Bird : Animal
    {
        int Speed { get; }
        public Bird(string name, bool isTakenCare, int speed) : base(name, isTakenCare)
        {
            Speed = speed;
        }
        public override string ToString()
        {
            return base.ToString() + $" Speed: {Speed}";
        }
        public override void DoSound()
        {
            Console.WriteLine("я птичка, пип-пип-пип");
        }
    }

    public class Zoo : IEnumerable
    {
        public List<Animal> Animals { get; }
        int i = 0;
        public Zoo(List<Animal> animals)
        {
            Animals = animals;
        }
        public IEnumerator GetEnumerator()
        {
            while (i < Animals.Count)
                yield return Animals[i++];
            if (i == Animals.Count) i = 0;
        }
    }


    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Random rand = new Random();
            List<Animal> animals = new List<Animal>();
            for (int i = 0; i < n; i++)
            {
                int which = rand.Next(2);
                bool isTakenCare = rand.Next(2) == 0 ? true : false;
                if (which == 0)
                    animals.Add(new Mammal(rand.Next(100, 1000).ToString(), isTakenCare, rand.Next(1, 20)));
                else
                    animals.Add(new Bird(rand.Next(100, 1000).ToString(), isTakenCare, rand.Next(1, 100)));
            }
            Zoo zoo = new Zoo(animals);
            foreach (Animal animal in zoo)
            {
                Console.WriteLine(animal);
                animal.DoSound();
            }
            Console.WriteLine();
            var birdsInCare = zoo.Animals.Where(animal => animal is Bird && animal.IsTakenCare);
            foreach (Animal animal in birdsInCare)
                Console.WriteLine(animal);
            Console.WriteLine();
            var mammalsNotInCare = zoo.Animals.Where(animal => animal is Mammal && !animal.IsTakenCare);
            foreach (Animal animal in mammalsNotInCare)
                Console.WriteLine(animal);
        }
    }
}
