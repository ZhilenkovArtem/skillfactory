using System;

namespace Module5
{
    class Task_5_5_3
    {
        static void Main(string[] args)
        {
            Echo(Console.ReadLine());
            Console.ReadKey();
        }
        static void Echo(string str)
        {
            Console.BackgroundColor = (ConsoleColor)str.Length;
            Console.WriteLine(str);
            if (str.Length > 1)
            {
                str = str.Remove(0, 1);
                Echo(str);
            }
        }
    }
}
