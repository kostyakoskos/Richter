using System;

// конструкторы значимых типов без параметров вызывается только явно
// конструктор по умолчани. ссылочного типа вызывается неявно

namespace Constructor
{
    internal struct Point
    {
        public Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
    }
    internal sealed class Rectangle
    {
        public Point m_topLeft, m_bottomRight;
        public Rectangle()
        {
            // В C# оператор new, использованный для создания экземпляра значимого
            // типа, вызывает конструктор для инициализации полей значимого типа
            m_topLeft = new Point(1, 2);
            m_bottomRight = new Point(100, 200);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle d = new();
            Point p = new Point();
            int i= 1;
            Console.WriteLine(i);
            Console.WriteLine("Hello World!");
        }
    }
}
