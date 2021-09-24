using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// два домена рабоьа.т в 1 потоке, при этом какой-то координации нет
// связи между доменами и потоками нет!

namespace DomainVsThread
{
    class MyClass : MarshalByRefObject
    {
        public void Operation()
        {
            Console.WriteLine("Opration domain: " + AppDomain.CurrentDomain.Id);
            Console.WriteLine("Opration threadId: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("Secound Domain");

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;// название домена domain myclass
            string typeName = typeof(MyClass).FullName;

            // для управление экземплярами нашего класса
            ObjectHandle handle = domain.CreateInstance(assemblyName, typeName);

            MyClass instance = handle.Unwrap() as MyClass;

            instance.Operation();

            Console.WriteLine("Main domain: " + AppDomain.CurrentDomain.Id);
            Console.WriteLine("Main threadId: " + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
        }
    }
}
