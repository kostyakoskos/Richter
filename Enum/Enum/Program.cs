using System;

namespace EnumType
{
    internal enum Color : byte
    {
        White,
        Red,
        Green,
        Blue,
        Orange
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));
            Color c = Color.Blue;
            Console.WriteLine(c); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString()); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString("G")); // "Blue" (Общий формат)
            Console.WriteLine(c.ToString("D")); // "3" (Десятичный формат)
            Console.WriteLine(c.ToString("X"));

            Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            Console.WriteLine("Number of symbols defined: " + colors.Length);
            Console.WriteLine("Value\tSymbol\n-----\t------");
            foreach (Color c1 in colors)
            {
                // Выводим каждый идентификатор в десятичном и общем форматах
                Console.WriteLine("{0,5:D}\t{0:G}", c1);
            }
        }
    }
}
