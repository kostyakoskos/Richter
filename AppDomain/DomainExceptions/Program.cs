using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

// объект после возникшего исключения в одном из его методов остается жив

namespace DomainExceptions
{
    class MyClass : MarshalByRefObject
    {
        public void Operation1()
        {
            Console.WriteLine("MyClass operation1: " + this.GetHashCode());
            throw new Exception("Exception in operation 1");
        }
        public void Operation2()
        {
            Console.WriteLine("MyClass operation2: " + this.GetHashCode());
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
            try
            {
                instance.Operation1();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.message: " + ex.Message);
            }
            instance.Operation2();
            Console.ReadKey();
        }
    }
}
