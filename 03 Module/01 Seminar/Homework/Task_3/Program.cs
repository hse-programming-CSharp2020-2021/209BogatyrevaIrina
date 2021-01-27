using System;
using static System.Console;

namespace Task_3
{
    class TemperatureConverterImp
    {
        public double MethodCToF(double c)
        {
            return Math.Round(c * 9 / 5 + 32, 3);
        }

        public double MethodFToC(double f)
        {
            return Math.Round((f - 32) * 5 / 9, 3);
        }
    }

    class Program
    {
        delegate double delegateConvertTemperature(double temp);
        static void Main()
        {
            TemperatureConverterImp temperature = new TemperatureConverterImp();
            delegateConvertTemperature FtoC = temperature.MethodFToC, CtoF = temperature.MethodCToF;
            double[] testTemp = { 0, 5, -5, 12.5, -12.5 };
            for (int i = 0; i < testTemp.Length; i++)
            {
                double currentTemp = FtoC(testTemp[i]);
                WriteLine($"{testTemp[i]} F = {currentTemp} C \n{currentTemp} C = {CtoF(currentTemp)} F\n");
            }
        }
    }
}
