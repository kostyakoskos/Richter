using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTask
{
    class Program
    {
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked { sum += n; } 
            }
            return sum;
        }
        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
                checked { sum += n; } // при больших n выдается System.OverflowException
            Console.WriteLine("Sum");
            return sum;
        }
        static void Main(string[] args)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task<Int32> t = new Task<Int32>(() => Sum(cts.Token, 10000), cts.Token);
            //t.Start();

            //cts.Cancel();

            //Task<Int32> t = Task.Run(() => Sum(CancellationToken.None, 10000));
            //// после завершения предыдущего задния начнется следующее, continueWith
            //Task cwt = t.ContinueWith(task => Console.WriteLine(
            // "The sum is: " + task.Result));
            //try
            //{
            //    Console.WriteLine("The sum is: " + t.Result);
            //}
            //catch (AggregateException x)
            //{
            //    x.Handle(e => e is OperationCanceledException);
            //    Console.WriteLine("Sum was canceled");
            //}

            //ContinueWith имеет флагиисполнения. Т.е. следующее задание можно выполнить когда предыдущее
            //выдало исключение OnlyOnRanToCompletion
            Task<Int32> t = Task.Run(() => Sum(10000));
            
            t.ContinueWith(task => Console.WriteLine("The sum is: " + task.Result),
             TaskContinuationOptions.OnlyOnRanToCompletion);
            //t.ContinueWith(task => Console.WriteLine("Sum was canceled"),
            // TaskContinuationOptions.OnlyOnCanceled);
           
            t.ContinueWith(task => Console.WriteLine("Sum threw: " + task.Exception),
             TaskContinuationOptions.OnlyOnFaulted);
            t.ContinueWith(task => Console.WriteLine("Sum was canceled"),
             TaskContinuationOptions.OnlyOnCanceled);
        }
    }
}
