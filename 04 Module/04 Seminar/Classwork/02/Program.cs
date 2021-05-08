using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class LucasCollection : IEnumerable<int>
    {
        int n;
        public LucasCollection(int n)
        {
            this.n = n;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new LucasCollectionEnumerator(n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LucasCollectionEnumerator(n);
        }

        private class LucasCollectionEnumerator : IEnumerator<int>
        {
            int first = 2, second = 1, position = -1, n;
            public int Current
            {
                get
                {
                    if (position == 0)
                        return first;
                    if (position == 1)
                        return second;
                    second = first + second;
                    first = second - first;
                    return second;
                }
            }
            public LucasCollectionEnumerator(int n)
            {
                this.n = n;
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++position < n;
            }

            public void Reset()
            {
                first = 2;
                second = 1;
                position = -1;
            }
        }

    }

    class Program
    {
        static void Main()
        {
            LucasCollection lc = new LucasCollection(int.Parse(Console.ReadLine()));
            foreach (int i in lc)
                Console.WriteLine(i);
        }
    }
}
