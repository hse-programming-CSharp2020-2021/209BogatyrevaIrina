using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using ClassLibrary1;

namespace Program1
{
    class Program
    {
        static List<Street> streets = new List<Street>();
        static Random rand = new Random();
        static void Main()
        {
            Write("Введите количество улиц (положительное число): ");
            if (!int.TryParse(ReadLine(), out int N) || N <= 0)
            {
                WriteLine("Неверный ввод. Будут использоваться первые 10 улиц из файла.");
                N = 10;
            }
            GetStreets(N);
            if (streets.Count > N)
                streets.RemoveRange(N, streets.Count - N);
            File.WriteAllText("out.txt", "");
            foreach (Street street in streets)
            {
                WriteLine(street);
                File.AppendAllText("out.txt", street.ToString() + "\n");
            }
        }

        static void GetStreets(int N)
        {
            try
            {
                string[] all = File.ReadAllLines("data.txt");
                if (!GetStreetsFromFile(all))
                    throw new ArgumentException();
                return;
            }
            catch (ArgumentException)
            {
                WriteLine("Неверный формат входных данных. Улицы будут сгенерированы случайным образом.");
            }
            catch (FileNotFoundException)
            {
                WriteLine("Файл data.txt не найден. Улицы будут сгенерированы случайным образом.");
            }
            catch (IOException)
            {
                WriteLine("При открытии файла data.txt произощла ошибка. " +
                    "Улицы будут сгенерированы случайным образом.");
            }
            catch (Exception)
            {
                WriteLine("Произошла неизвестная ошибка. Улицы будут сгенерированы случайным образом.");
            }
            GenerateStreets(N);
        }

        static bool GetStreetsFromFile(string[] all)
        {
            foreach (string line in all)
            {
                string[] info = line.Split();
                if (info.Length < 2)
                    return false;
                int[] houses = new int[info.Length - 1];
                for (int i = 1; i < info.Length; i++)
                {
                    if (!int.TryParse(info[i], out int house) || house < 1)
                        return false;
                    houses[i - 1] = house;
                }
                streets.Add(new Street(info[0], houses));
            }
            return true;
        }

        static void GenerateStreets(int N)
        {
            streets = new List<Street>(N);
            for (int n = 0; n < N; n++)
            {
                string name = GenerateName();
                int[] houses = new int[rand.Next(1, 10)];
                for (int i = 0; i < houses.Length; i++)
                    houses[i] = rand.Next(1, 101);
                streets.Add(new Street(name, houses));
            }
        }

        static string GenerateName()
        {
            int length = rand.Next(3, 10);
            string name = "" + (char)rand.Next('А', 'Я' + 1);
            for (int i = 1; i < length; i++)
                name += (char)rand.Next('а', 'я' + 1);
            return name;
        }
    }
}
