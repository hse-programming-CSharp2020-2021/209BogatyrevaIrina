using System;
using System.IO;
using System.Xml.Serialization;

namespace _02
{
    public class Student
    {
        public string name;
        public int year;
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
        public int getYear()
        {
            return year;
        }
        Student() { }
    }

    public class Group
    {
        public Student[] students;
        public Group(Student[] students)
        {
            this.students = students;
        }
        Group() { }
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

            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream("Test2.xml", FileMode.Create))
            {
                serializer.Serialize(fs, group);
            }

            Console.WriteLine("***");
            Group newGroup;
            using (FileStream fs = new FileStream("Test2.xml", FileMode.Open))
            {
                newGroup = (Group)serializer.Deserialize(fs);
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

