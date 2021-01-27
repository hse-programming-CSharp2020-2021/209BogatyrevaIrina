using System;
using static System.Console;

namespace Task_4
{
    class Robot
    {
        int x, y;

        public void Right() { x++; }
        public void Left() { x--; }
        public void Forward() { y++; }
        public void Backward() { y--; }
        public string Position()
        {
            return $"Position: x = {x}, y = {y}";
        }
    }

    class Program
    {
        delegate void Steps();
        static void Main()
        {
            Robot rob = new Robot();
            Steps steps = null;
            Write("Input commands: ");
            string S = ReadLine();
            WriteLine("Initial " + rob.Position());
            try
            {
                foreach (char command in S)
                {
                    switch (command)
                    {
                        case 'R':
                            steps += rob.Right;
                            break;
                        case 'L':
                            steps += rob.Left;
                            break;
                        case 'F':
                            steps += rob.Forward;
                            break;
                        case 'B':
                            steps += rob.Backward;
                            break;
                        default:
                            throw new Exception($"Exception! Command {command} is unknown.");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return;
            }
            steps();
            WriteLine("Final " + rob.Position());
        }
    }
}
