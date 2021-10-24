using System;
using System.Linq;

namespace Module5
{
    class _5_6_Final
    {
        public static
            (string Name, string Surname, byte Age,
             bool HasPet, string[] PetsNicknames,
             ConsoleColor[] FavoriteColors) Person;
        public static void Main()
        {
            while (true)
            {
                EnterPersonData();
                Console.Clear();
                OutputPersonInfo();
                if (Console.ReadLine() == "exit") Environment.Exit(0);
                ClearPerson();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
        }
        public static void EnterPersonData()
        {
            Console.WriteLine("Введите ваше имя:");
            Person.Name = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию:");
            Person.Surname = Console.ReadLine();
            EnterAge();
            Console.WriteLine("У вас есть питомец?\n"+
                "Введите \"Y\", если есть, или другой символ в ином случае");
            Person.HasPet = Console.ReadLine() == "Y" ? true : false;
            if (Person.HasPet) EnterPetsCount();
            EnterColorsCount();
        }
        public static void EnterAge()
        {
            Console.WriteLine("Введите ваш возраст:");
            byte age;
            bool trueConvertByte =
                byte.TryParse(Console.ReadLine(), out age);
            if (!trueConvertByte || age < 0)
            {
                Console.Write("Возраст введен неверно. ");
                EnterAge();
            }
            else
                Person.Age = age;
        }
        public static void EnterPetsCount()
        {
            Console.WriteLine("Введите количество ваших питомцев:");
            byte petsCount;
            bool trueConvertByte =
                byte.TryParse(Console.ReadLine(), out petsCount);
            if (!trueConvertByte || petsCount < 1)
            {
                Console.Write("Число введено неверно. ");
                EnterPetsCount();
            }
            else
                EnterPets(petsCount);
        }
        public static void EnterColorsCount()
        {
            Console.WriteLine("Введите количество ваших любимых цветов:");
            byte colorsCount;
            bool trueConvertByte =
                byte.TryParse(Console.ReadLine(), out colorsCount);
            if (!trueConvertByte || colorsCount < 0)
            {
                Console.Write("Число введено неверно. ");
                EnterColorsCount();
            }
            else
                EnterColors(colorsCount);
        }
        public static void EnterPets(byte petsCount)
        {
            var pets = new string[petsCount];
            for (int i = 0; i < petsCount; i++)
            {
                Console.WriteLine($"Введите имя {i + 1} питомца:");
                pets[i] = Console.ReadLine();
            }
            Person.PetsNicknames = pets;
        }
        public static void EnterColors(byte colorsCount)
        {
            var colors = new ConsoleColor[colorsCount];
            for (int i = 0; i < colorsCount; i++)
            {
                try
                {
                    Console.WriteLine($"Введите ваш {i + 1} любимый цвет:");
                    colors[i] = (ConsoleColor)Enum.Parse(typeof(ConsoleColor),
                                                         Console.ReadLine());
                }
                catch
                {
                    Console.Write("Цвет введен неверно. ");
                    i--;
                }
            }
            Person.FavoriteColors = colors;
        }
        public static void OutputPersonInfo()
        {
            Console.WriteLine($"Ваше имя: {Person.Name}\n" +
                              $"Ваша фамлия: {Person.Surname}\n" +
                              $"Ваш возраст: {Person.Age}");
            if (!Person.HasPet)
                Console.WriteLine("У вас нет питомцев");
            else
            {
                for (int i = 0; i < Person.PetsNicknames.Count(); i++)
                {
                    Console.WriteLine(
                        $"Имя {i + 1} питомца: {Person.PetsNicknames[i]}");
                }
            }
            if (!Person.FavoriteColors.Any())
                Console.WriteLine("У вас нет любимых цветов");
            else
            {
                for (int i = 0; i < Person.FavoriteColors.Count(); i++)
                {
                    Console.BackgroundColor = Person.FavoriteColors[i];
                    Console.WriteLine(
                        $"Название {i + 1} любимого цвета: " + 
                        $"{Person.FavoriteColors[i]}");
                }
            }
        }
        public static void ClearPerson()
        {
            Person.Name = null;
            Person.Surname = null;
            Person.Age = 0;
            Person.HasPet = false;
            Person.PetsNicknames = new string[0];
            Person.FavoriteColors = new ConsoleColor[0];
        }
    }
}
