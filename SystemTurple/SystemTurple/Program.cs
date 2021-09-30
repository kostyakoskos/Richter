using System;
// bad to use system.tuple
namespace SystemTurple
{
    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
    {
        private T1 m_Item1; private T2 m_Item2;
        private T3 m_Item3; private T4 m_Item4;
        private T5 m_Item5; private T6 m_Item6;
        private T7 m_Item7; private TRest m_Rest;
        public Tuple(T1 item1, T2 item2, T3 item3,
        T4 item4, T5 item5, T6 item6, T7 item7, TRest t)
        {
            m_Item1 = item1; m_Item2 = item2; m_Item3 = item3; m_Item4 = item4;
            m_Item5 = item5; m_Item6 = item6; m_Item7 = item7; m_Rest = t;
        }
        public T1 Item1 { get { return m_Item1; } }
        public T2 Item2 { get { return m_Item2; } }
        public T3 Item3 { get { return m_Item3; } }
        public T4 Item4 { get { return m_Item4; } }
        public T5 Item5 { get { return m_Item5; } }
        public T6 Item6 { get { return m_Item6; } }
        public T7 Item7 { get { return m_Item7; } }
        public TRest Rest { get { return m_Rest; } }
    }
    class Program
    {
        private static Tuple<Int32, Int32> MinMax(Int32 a, Int32 b)
        {
            return new Tuple<Int32, Int32>(Math.Min(a, b), Math.Max(a, b));
        }
        // Пример вызова метода и использования Tuple
        private static void TupleTypes()
        {
            var minmax = MinMax(6, 2);
            Console.WriteLine("Min={0}, Max={1}",minmax.Item1, minmax.Item2); // Min=2, Max=6
        }
        static void Main(string[] args)
        {
            TupleTypes();
        }
    }
}
