using System;
using System.Threading;

namespace ThreadA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: starting a dedicated thread " +
 "to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000); // Имитация другой работы (10 секунд)
            dedicatedThread.Join(); // Ожидание завершения потока
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }
    }
}
