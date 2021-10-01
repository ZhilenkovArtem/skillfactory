using System;

namespace Module4
{
    class Task_4_1_17
    {
		public static void CreateTextToConsole(ConsoleColor backColor, ConsoleColor frontColor)
		{
			Console.BackgroundColor = backColor;
			Console.ForegroundColor = frontColor;
			Console.WriteLine("Your color is {0}!", backColor);
		}

		public static void Main()
		{
			Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");

			var color = Console.ReadLine();

			if (color == "red")
			{
				CreateTextToConsole(ConsoleColor.Red, ConsoleColor.Black);
			}
			else if (color == "green")
			{
				CreateTextToConsole(ConsoleColor.Green, ConsoleColor.Black);
			}
			else
			{
				CreateTextToConsole(ConsoleColor.Cyan, ConsoleColor.Black);
			}
		}
	}
}
