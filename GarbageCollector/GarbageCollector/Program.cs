using System;
using System.Threading;

namespace GarbageCollector
{
    public static class Program
    {
        //public static void Main()
        //{
        //    //// Создание объекта Timer, вызывающего метод TimerCallback
        //    //// каждые 2000 миллисекунд
        //    //Timer t = new Timer(TimerCallback, null, 0, 2000);

        //    //// Ждем, когда пользователь нажмет Enter
        //    //Console.ReadLine();

        //    Timer t = new Timer(TimerCallback, null, 0, 2000);
        //    Console.ReadLine();
        //    t.Dispose();
        //}
        //private static void TimerCallback(Object o)
        //{
        //    // Вывод даты/времени вызова этого метода
        //    Console.WriteLine("In TimerCallback: " + DateTime.Now);
        //    // Принудительный вызов уборщика мусора в этой программе
        //    GC.Collect();
        //}
        public static void Main(string[] args)
        {
            var timer = new Timer(TimerCallback, null, 0, 1000); // call every second
            Console.ReadLine();
        }

        public static void TimerCallback(Object o)
        {
            Console.WriteLine("Callback!");
            GC.Collect();
        }
    }
}
