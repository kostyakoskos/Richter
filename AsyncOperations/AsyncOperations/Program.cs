using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// Пример процедуры асинхронного вызова метода потоком из пула:
namespace AsyncOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000); // Имитация другой работы (10 секунд)
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }
        private static void ComputeBoundOp(Object state)
        {
            // Метод выполняется потоком из пула
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000); // Имитация другой работы (1 секунда)
                                // После возвращения управления методом поток
                                // возвращается в пул и ожидает следующего задания
        }
    }
}
