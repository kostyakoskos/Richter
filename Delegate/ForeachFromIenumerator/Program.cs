using System;
using System.Collections.Generic;

namespace ForeachFromIenumerator
{
    class Program
    {
        static void PrintNamesAndAges(IEnumerable<string> names, IEnumerable<int> ages)
        {
            using (IEnumerator<int> ageIterator = ages.GetEnumerator())
            {
                foreach (string name in names)
                {
                    if (!ageIterator.MoveNext())
                    {
                        throw new ArgumentException("Not enough ages");
                    }
                    Console.WriteLine("{0} is {1} years old", name, ageIterator.Current);
                }
                if (ageIterator.MoveNext())
                {
                    throw new ArgumentException("Not enough names");
                }

            }
        }
        delegate void Printer();
        static void Main(string[] args)
        {
            List<string> a = new List<string>();
            a.Add("asd");
            List<int> b = new List<int>();
            b.Add(2);

            PrintNamesAndAges(a, b);

            // И вот почему: delegate добавляется циклически, однако параметр i передаётся по ссылке.
            // Поэтому, по окончании цикла i равно 10, и при каждом запуске delegate будет
            // выводиться работать с этим значением
            List<Printer> printers = new List<Printer>();// array of delegate
            List<int> p = new List<int>();
            p.Add(1);
            for (int i = 0; i < 10; i++)
            {
                printers.Add(delegate { int d = i; i += 10; Console.WriteLine("Hello" + i); });
            }
            //GC.Collect();
            // делегат не запускется пока его не вызовут. это происхолит во втором цикле. 
            foreach (var printer in printers)
            {
                printer();
            }
        }
    }
}
