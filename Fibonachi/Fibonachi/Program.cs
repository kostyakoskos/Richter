using System;

namespace Fibonachi
{
    class MyClass
    {
        public void Method() { Console.WriteLine("Method"); }
    }
    class ClassA
    {
        public ClassA() { }

        public ClassA(int pValue) { }
    }
    class Program
    {
        static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
        public static int Fibonachi2(int f)
        {
            int a = 0, b = 1, temp = 0;

            for(int i = 0; i < f; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return a;
        }
        static string location;
        static DateTime time;
        static void Main(string[] args)
        {
            //MyClass c = null;
            //c.Method();
            Console.WriteLine(Fibonachi(10));
            Console.WriteLine(Fibonachi2(10));
            ClassA refA = new ClassA();
            
            Console.WriteLine(location == null ? "location is null" : location);
            Console.WriteLine(time == null ? "time is null" : time.ToString());
        }
    }
}
