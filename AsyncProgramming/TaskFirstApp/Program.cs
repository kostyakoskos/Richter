using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFirstApp
{
    class Program
    {
        // Метод выполняемый в качестве задачи
        static void MyTask()
        {
            Console.WriteLine("MyTask() {0}", Task.CurrentId);

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Count = " + count);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread");

            Task task = new Task(MyTask);
            Task task2 = new Task(MyTask);

            task.Start();
            task2.Start();

            var a = task.Status;
            Console.WriteLine(a.GetType());
            Console.WriteLine(a);
            // ожидание пока заверщается задание 1,2
            task.Wait();
            Console.WriteLine(task.Status);
            Console.WriteLine(task2.Status);
            task2.Wait();
            //Task.WaitAll(task, task2); // waitany- пока завершится любая из task
            
            //for (int i = 0; i < 60; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(100);
            //}

            Console.WriteLine("Main thread finish");
            //task.Start();
            Console.ReadLine();
        }
    }
}
