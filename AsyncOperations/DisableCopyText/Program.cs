using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisableCopyText
{
    class Program
    {
        static void Main(string[] args)
        {
            CallContext.LogicalSetData("Name", "Jeffrey");
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}",
                CallContext.LogicalGetData("Name")));

            // запрет на копирование контекста потока main
            ExecutionContext.SuppressFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}",
                CallContext.LogicalGetData("Name")));
            // ExecutionContext.RestoreFlow();

            Console.ReadKey();
        }
    }
}
