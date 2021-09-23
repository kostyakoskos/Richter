using System;

namespace GenericInterface
{
    // Этот класс реализует обобщенный интерфейс IComparable<T> дважды
    public sealed class Number : IComparable<Int32>, IComparable<String>
    {
        private Int32 m_val = 5;
        // Этот метод реализует метод CompareTo интерфейса IComparable<Int32>
        public Int32 CompareTo(Int32 n)
        {
            return m_val.CompareTo(n);
        }
        // Этот метод реализует метод CompareTo интерфейса IComparable<String>
        public Int32 CompareTo(String s)
        {
            return m_val.CompareTo(Int32.Parse(s));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Number n = new Number();
            // Значение n сравнивается со значением 5 типа Int32
            IComparable<Int32> cInt32 = n;
            Console.WriteLine(cInt32.CompareTo(5));
            // Значение n сравнивается со значением "5" типа String
            IComparable<String> cString = n;
            Console.WriteLine(cString.CompareTo("5"));
        }
    }
}
