using System;
using System.Collections;

namespace YieldIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
    class Numbers
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                // we must yield return like a iterator
                yield return i * i;
            }
        }
    }
}
