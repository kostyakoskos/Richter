using System;

namespace ConstReadOnly
{
    public sealed class SomeType
    {
        public static readonly Random s_random = new Random();
        private static Int32 s_numberOfWrites = 0;
        public readonly String Pathname = "Untitled";
        private System.IO.FileStream m_fs;
        public SomeType(String pathname)
        {
            this.Pathname = pathname;
        }
        public String DoSomething()
        {
            s_numberOfWrites = s_numberOfWrites + 1;
            return Pathname;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
