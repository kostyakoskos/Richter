using System;
using System.Threading;

namespace Threads
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main thread: starting a dedicated thread " +
            "to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(1);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(100); // Имитация другой работы (10 секунд)
            dedicatedThread.Join(); // Ожидание завершения потока
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }
        // Сигнатура метода должна совпадать
        // с сигнатурой делегата ParameterizedThreadStart
        private static void ComputeBoundOp(Object state)
        {
            // Метод, выполняемый выделенным потоком
            Console.WriteLine("---");
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(100); // Имитация другой работы (1 секунда)
                                // После возвращения методом управления выделенный поток завершается
        }
    }
}