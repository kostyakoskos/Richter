using System;

namespace ParametrProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray ba = new BitArray(14);
            for (Int32 x = 0; x < 14; x++)
            {
                ba[x] = (x % 2 == 0);
            }
            for (Int32 x = 0; x < 14; x++)
            {
                Console.WriteLine("Bit " + x + " is " + (ba[x] ? "On" : "Off"));
            }
            Console.WriteLine("Hello World!");
        }
    }
}
