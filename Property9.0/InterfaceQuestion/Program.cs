using System;

namespace InterfaceQuestion
{
    class MyClass : Interface1, Interface2
    {
        public string Name { get; set; }
        void Interface1.Move()
        {
            Console.WriteLine("Move");
        }
        void Interface2.Move()
        {
            Console.WriteLine("Move");
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            MyClass c = new();
            c.Name = "wdw";
            c.Move();
            Console.WriteLine();
        }
    }
}
