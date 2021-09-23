using System;

// generic method- we can call with different types of parametr(ex.: int, string,...)
namespace GenericMethod
{
    internal sealed class GenericType<T>
    {
        private T m_value;
        public GenericType(T value) { m_value = value; }
        public TOutput Converter<TOutput>()
        {
            TOutput result = (TOutput)Convert.ChangeType(m_value, typeof(TOutput));
            return result;
        }
    }
    class Program
    {
        private static void Swap<T>(ref T o1, ref T o2)
        {
            T temp = o1;
            o1 = o2;
            o2 = temp;
        }
        private static void CallingSwap()
        {
            Int32 n1 = 1, n2 = 2;
            Console.WriteLine("n1={0}, n2={1}", n1, n2);
            Swap<Int32>(ref n1, ref n2);
            Console.WriteLine("n1={0}, n2={1}", n1, n2);

            String s1 = "Aidan", s2 = "Grant";
            Console.WriteLine("s1={0}, s2={1}", s1, s2);
            Swap<String>(ref s1, ref s2);
            Console.WriteLine("s1={0}, s2={1}", s1, s2);
        }
        static void Main(string[] args)
        {
            Program.CallingSwap();
            Console.WriteLine("Hello World!");
        }
    }
}
