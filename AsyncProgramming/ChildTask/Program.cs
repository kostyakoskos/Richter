using System;
using System.Threading.Tasks;

namespace ChildTask
{
    class Program
    {
        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
                checked { sum += n; } // при больших n выдается System.OverflowException
            //Console.WriteLine("Sum");
            return sum;
        }
        static void Main(string[] args)
        {
            Task<Int32[]> parent1 = new Task<Int32[]>(() =>
            {
                //Console.WriteLine("Task parent generated");
                var results = new Int32[3];

                new Task(() => results[0] = Sum(10),
                TaskCreationOptions.AttachedToParent).Start();
                //Console.WriteLine("first");
                new Task(() => results[1] = Sum(11),
                TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(12),
                TaskCreationOptions.AttachedToParent).Start();

                return results;
            });
            parent1.Start();
            var cwt = parent1.ContinueWith(parentTask => Array.ForEach(parentTask.Result,
                Console.WriteLine));

            //var parent = Task.Factory.StartNew(() => {
            //    Console.WriteLine("Outer task executing.");

            //    var child = Task.Factory.StartNew(() => {
            //        Console.WriteLine("Nested task starting.");
            //        Console.WriteLine("Nested task completing.");
            //    });
            //});
            //parent.Wait();
            //Console.WriteLine("Outer has completed.");
            Console.WriteLine("---");
                      
        }
    }
}
