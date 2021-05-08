using System;
using System.Collections;
using System.Collections.Generic;

namespace _01
{
    class RandomCollection : IEnumerable<int>
    {
        int[] collection;
        public RandomCollection(int n)
        {
            Random rand = new Random();
            collection = new int[n];
            for (int i = 0; i < n; i++)
                collection[i] = rand.Next(100);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new RandomEnumerator(collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new RandomEnumerator(collection);
        }

        private class RandomEnumerator : IEnumerator<int>
        {
            int position = -1;
            readonly int[] array;
            public RandomEnumerator(int[] array)
            {
                this.array = array;
            }
            public int Current
            {
                get
                {
                    return array[position];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                return ++position < array.Length;
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {
            }
        }
    }

    class Program
    {
        static void Main()
        {
            RandomCollection rc = new RandomCollection(10);
            foreach (var j in rc)
                Console.Write($"{j} ");
            Console.WriteLine();
            IEnumerator<int> ie = rc.GetEnumerator();
            while (ie.MoveNext())
                Console.Write($"{ie.Current} ");
        }
    }
}
