using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LockMonitorMutexSemaphore
{
    class Program
    {
        private static string result;
        private static void ComputeBoundOp(Object state)
        {
            // Метод, выполняемый выделенным потоком
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000); // Имитация другой работы (1 секунда)
                                // После возвращения методом управления выделенный поток завершается
        }
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                // Следующая строка приводит к исключению OperationCanceledException
                // при вызове метода Cancel для объекта CancellationTokenSource,
                // на который ссылается маркер
                ct.ThrowIfCancellationRequested();
                checked { sum += n; } // при больших n появляется
                                      // исключение System.OverflowException
            }
            return sum;
        }
        private static Int32 Sum1(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
                checked { sum += n; } // при больших n выдается System.OverflowException
            return sum;
        }
        static void Main()
        {
            //SaySomething();
            //Console.WriteLine(result);
            //ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5); // Вызов QueueUserWorkItem
            //new Task(ComputeBoundOp, 5).Start(); // Аналог предыдущей строки
            //Task.Run(() => ComputeBoundOp(5)); // Еще один аналог
            Console.WriteLine("---");

            // Создание задания Task (оно пока не выполняется)
            Task<Int32> t = new Task<Int32>(n => Sum1((Int32)n), 1000000000);
            // Можно начать выполнение задания через некоторое время
            t.Start();
            // Можно ожидать завершения задания в явном виде
            t.Wait(); // ПРИМЕЧАНИЕ. Существует перегруженная версия,
                      // принимающая тайм-аут/CancellationToken
                      // Получение результата (свойство Result вызывает метод Wait)
            Console.WriteLine("The Sum is: " + t.Result); // Значение Int32

            Console.WriteLine("---");
            /*
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Int32> t = new Task<Int32>(() => Sum(cts.Token, 10000), cts.Token);
            t.Start();
            // Позднее отменим CancellationTokenSource, чтобы отменить Task
            cts.Cancel(); // Это асинхронный запрос, задача уже может быть завершена
            try
            {
                // В случае отмены задания метод Result генерирует
                // исключение AggregateException
                Console.WriteLine("The sum is: " + t.Result); // Значение Int32
            }
            catch (AggregateException x)
            {
                // Считаем обработанными все объекты OperationCanceledException
                // Все остальные исключения попадают в новый объект AggregateException,
                // состоящий только из необработанных исключений
                x.Handle(e => e is OperationCanceledException);
                // Строка выполняется, если все исключения уже обработаны
                Console.WriteLine("Sum was canceled");
            }*/

        }

        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            result = "Hello world!";
            return "Something";
        }
    }
}
