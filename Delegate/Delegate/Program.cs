using System;

namespace Delegate
{
    public delegate void Mydelegate();

    public delegate int AddDelegate(int a, int b);

    class Mathematics
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }
    }

    class SomeClass
    {
        public static void Method()
        {
            Console.WriteLine("Hello");
        }
        public static void HelloMethodDelegate()
        {
            Console.WriteLine("Hello Delegate method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mydelegate mD = new Mydelegate(SomeClass.Method);

            mD.Invoke();

            mD();
            Console.WriteLine("Hello World!");

            Mathematics m = new Mathematics();
            Console.WriteLine(m.Add(2, 3));
            AddDelegate aD = new AddDelegate(m.Add);

            Console.WriteLine(aD.Invoke(20,3));// вызываем метод при помощи делегата

            Console.ReadKey();
        }
    }
}
