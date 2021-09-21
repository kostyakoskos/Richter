using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int, int> op;
            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);
            Console.WriteLine("Hello World!");

            Func<string, string> selector = (str) => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);
            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);

            Console.Read();
        }
        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }
        static void Substract(int x1, int x2)
        {
            Console.WriteLine("diff {0}", (x1 - x2));
        }
        static void Add(int x1, int x2)
        {
            Console.WriteLine("sum {0}", (x1 + x2));
        }
    }
}
