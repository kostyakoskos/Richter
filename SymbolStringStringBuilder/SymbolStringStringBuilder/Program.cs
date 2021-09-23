using System;

namespace SymbolStringStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Double d; // '\u0033' – это "цифра 3"
            d = Char.GetNumericValue('\u0033'); // Параметр '3'
                                                // даст тот же результат
            Console.WriteLine(d.ToString()); // Выводится "3"
                                             // '\u00bc' — это "простая дробь одна четвертая ('1/4')"
            d = Char.GetNumericValue('\u00bc');
            Console.WriteLine(d.ToString()); // Выводится "0.25"
                                             // 'A' — это "Латинская прописная буква A"
            d = Char.GetNumericValue('A');
            Console.WriteLine(d.ToString()); // Выводится "-1"
        }
    }
}
