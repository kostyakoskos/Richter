using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactory
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
        static void Main(string[] args)
        {
            /*Console.WriteLine("Main thread start");

            // Используем лямбда-выражение
            Task task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("MyTask() {0} start", Task.CurrentId);

                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("In method MyTask {0} count = {1}", Task.CurrentId, count);
                }

                Console.WriteLine("MyTask() #{0} finish", Task.CurrentId);
            });

            task1.Wait();
            task1.Dispose();

            Console.WriteLine("Main thread finish");
            Console.ReadLine();*/
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<Int32>(cts.Token,
                TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);

                var childTasks = new[] {
                    tf.StartNew(() => Sum(cts.Token, 10000)),
                    tf.StartNew(() => Sum(cts.Token, 20000)),
                    tf.StartNew(() => Sum(cts.Token, Int32.MaxValue))  };

                for (Int32 task = 0; task < childTasks.Length; task++)
                    childTasks[task].ContinueWith(
                    t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                tf.ContinueWhenAll(
                childTasks, completedTasks => completedTasks.Where(
                 t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result),
                CancellationToken.None)
                .ContinueWith(t => Console.WriteLine("The maximum is: " + t.Result),
                TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                StringBuilder sb = new StringBuilder(
                "The following exception(s) occurred:" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine(" " + e.GetType().ToString());
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);
            parent.Start();
        }
    }
}
