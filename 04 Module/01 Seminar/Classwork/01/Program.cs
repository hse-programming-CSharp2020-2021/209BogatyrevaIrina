using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _01
{
    [Serializable]
    class Student
    {
        public string name;
        private int year;
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
        public int getYear()
        {
            return year;
        }
    }

    [Serializable]
    class Group
    {
        public Student[] students;
        public Group(Student[] students)
        {
            this.students = students;
        }
    }


    class Program
    {
        const int N = 10;

        static string CreateName()
        {
            Random rand = new Random();
            string name = ((char)rand.Next('A', 'Z' + 1)).ToString();
            for (int i = 0; i < 9; i++)
                name += (char)rand.Next('a', 'z' + 1);
            return name;
        }

        static void Main()
        {
            Random rand = new Random();
            Group group = new Group(new Student[N]);
            for (int i = 0; i < N; i++)
            {
                group.students[i] = new Student(CreateName(), rand.Next(10, 151));
                Console.WriteLine($"{group.students[i].name} {group.students[i].getYear()}");
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("Test1.bin", FileMode.Create))
            {
                bf.Serialize(fs, group);
            }

            Console.WriteLine("***");
            Group newGroup;
            using (FileStream fs1 = new FileStream("Test1.bin", FileMode.Open))
            {
                newGroup = (Group)bf.Deserialize(fs1);
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{newGroup.students[i].name} {newGroup.students[i].getYear()}");
                if (group.students[i].name != newGroup.students[i].name ||
                    group.students[i].getYear() != newGroup.students[i].getYear())
                    Console.WriteLine("\nIncorrect Deserialization\n");
            }
        }
    }
}

