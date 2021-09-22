using System;

namespace ChangeFieldBoxValueType
{
    internal struct Point : IChangeBoxedPoint
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        public void Change(Int32 x, Int32 y)
        {
            m_x = x; m_y = y;
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
    }
    internal interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Point p = new Point(1, 1);
            //Console.WriteLine(p);// boxing
            //p.Change(2, 2);
            //Console.WriteLine(p);
            //Object o = p;// упаковка p
            //Console.WriteLine(o);
            //((Point)o).Change(3, 3);
            //Console.WriteLine(o);
            // 1,1 2,2 2,2


            Point p = new Point(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((Point)o).Change(3, 3);
            Console.WriteLine(o);

            // создается ещё 1 объект в куче, заполняется 4 4  и подподает под сборщик мусора.
            ((IChangeBoxedPoint)p).Change(4, 4);// p упаковывается, упакованный объект изменяется и освобождается
            Console.WriteLine(p);

            ((IChangeBoxedPoint)o).Change(5, 5); // Упакованный объект изменяется и выводится
            Console.WriteLine(o);
        }
    }
}
