using System;

namespace Lambda
{
    public delegate void HelloDelegate();
    public delegate bool CompareDelegate(string a, string b);
    public delegate void Hello2Delegate(string s);
    public delegate int SubDelegate(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            HelloDelegate hd = () => Console.WriteLine("Hello");
            hd();
            hd.Invoke();
            CompareDelegate cd = (x, y) => x == y;

            // Console.WriteLine(cd(3, 3));

            Console.WriteLine(cd("G\n", "G\nt"));

            Console.WriteLine("Hello World!");


            Hello2Delegate h = (x) =>
            {
                Console.WriteLine("Hello " + x);
                Console.WriteLine("Hello from 2 " + x);
            };
            //h("WorldW");
            SubDelegate s = (x, y) =>
            {
                return x - y;
            };

            int sew = new SubDelegate((x, y) =>
            {
                int k = x - y; 
                return k;
            }).Invoke(23,2);

            Console.WriteLine(s(100, 10));
            Console.WriteLine(sew);
            //Func<Int32, Int32, String> f3 = (Int32 n1, Int32 n2) => (n1 + n2).ToString();
            //Console.WriteLine(f3(1, 2, "sd"));
            Console.ReadKey();
        }
    }
}
