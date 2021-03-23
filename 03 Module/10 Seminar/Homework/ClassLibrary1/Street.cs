using System;

namespace ClassLibrary1
{
    public class Street
    {
        public readonly string name;
        int[] houses;

        public Street(string name, int[] houses)
        {
            this.name = name;
            this.houses = houses;
        }

        public static int operator ~(Street street)
        {
            return street.houses.Length;
        }

        public static bool operator !(Street street)
        {
            foreach (int house in street.houses)
                if (house.ToString().Contains('7'))
                    return true;
            return false;
        }

        public override string ToString()
        {
            string res = name;
            foreach (int house in houses)
                res += $" {house}";
            return res;
        }
    }
}
