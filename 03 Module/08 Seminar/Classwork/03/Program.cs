using System;

namespace _03
{
    class Arr<T>
    {
        T[] array = new T[0];
        public void Add(T newOne)
        {
            T[] newArray = new T[array.Length + 1];
            Array.Copy(array, newArray, array.Length);
            newArray[array.Length] = newOne;
            array = newArray;
        }

        public T RemoveAt(int index)
        {
            T[] newArray = new T[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, newArray.Length - index);
            T res = array[index];
            array = newArray;
            return res;
        }
        public T this[int index] { get { return array[index]; } }
        public int ArrayLength { get { return array.Length; } }
        public override string ToString()
        {
            string res = "";
            foreach (T el in array)
                res += $"{el} ";
            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            Arr<int> intArr = new Arr<int>();
            for (int i = 0; i < 10; i++)
                intArr.Add(i);
            Console.WriteLine(intArr);
            Console.WriteLine(intArr[5]);
            intArr.RemoveAt(7);
            intArr.RemoveAt(3);
            Console.WriteLine(intArr);
        }
    }
}
