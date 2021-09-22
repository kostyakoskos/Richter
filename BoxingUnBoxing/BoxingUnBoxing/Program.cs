using System;
using System.Collections;

namespace BoxingUnBoxing
{
    struct Point
    {
        public Int32 x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*1
            ArrayList a = new ArrayList();
            Point p; // Выделяется память для Point (не в куче)
            for (Int32 i = 0; i < 10; i++)
            {
                p.x = p.y = i; // Инициализация членов в нашем значимом типе
                a.Add(p); // Упаковка значимого типа и добавление
                          // ссылки в ArrayList
            }*/
            //2
            //Int32 x = 5;
            //Object o = x; // Упаковка x; o указывает на упакованный объект
            //Int16 y = (Int16)o; // Генерируется InvalidCastException

            /* 3Int32 v = 5; // Создаем переменную упакованного значимого типа

            // При компиляции следующей строки v упакуется
            // три раза, расходуя и время, и память
            Console.WriteLine("{0}, {1}, {2}", v, v, v);

            // Следующие строки дают тот же результат,
            // но выполняются намного быстрее и расходуют меньше памяти
            Object o = v; // Упакуем вручную v (только единожды)
                          // При компиляции следующей строки код упаковки не создается
            Console.WriteLine("{0}, {1}, {2}", o, o, o);*/

        }
    }
}
