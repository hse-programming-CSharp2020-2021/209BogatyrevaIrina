using System;
using System.IO;
using static System.Console;
using ClassLibrary1;

namespace Program2
{
    class Program
    {
        static void Main()
        {
            Street[] streets;
            try
            {
                string[] all = File.ReadAllLines("../../../../Program/bin/Debug/netcoreapp3.1/out.txt");
                streets = new Street[all.Length];
                for (int i = 0; i < all.Length; i++)
                {
                    string[] info = all[i].Split();
                    int[] houses = new int[info.Length - 1];
                    for (int j = 1; j < info.Length; j++)
                        houses[j - 1] = int.Parse(info[j]);
                    streets[i] = new Street(info[0], houses);
                }
            }
            catch (Exception ex)
            {
                WriteLine("Не удалось прочитать файл или неверный формат данных в файле.\n" +
                    $"{ex.Message}");
                return;
            }
            foreach (Street street in streets)
                WriteLine(street);
            WriteLine("\nВолшебные улицы:\n");
            foreach (Street street in streets)
                if (~street % 2 == 1 && !street)
                    WriteLine(street);
        }
    }
}
