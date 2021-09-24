using System;
using System.Runtime.ExceptionServices;
using System.Reflection;
using System.Runtime.Remoting;

namespace DomainExceptionFirst
{
    class MyClass : MarshalByRefObject
    {
        public void Operation()
        {
            throw new Exception("Error in operation method");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("Secound Domain");
            // если во втором домене возникнет ошибка, то событие вызовет invoke
            domain.FirstChanceException += Domain_FirstChanceException;

            string asembly = Assembly.GetExecutingAssembly().GetName().Name;
            string typeName = typeof(MyClass).FullName;

            ObjectHandle handle = domain.CreateInstance(asembly, typeName);

            MyClass instance = handle.Unwrap() as MyClass;

            try
            {
                instance.Operation();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Try catch: ");
                Console.WriteLine("Exception in domain " + domain.FriendlyName);
                Console.WriteLine("e.ExeptionMessage  " + ex.Message);
            }
            Console.WriteLine("Domen working current " + AppDomain.CurrentDomain.Id);
            Console.WriteLine("Domen working domain " + domain.FriendlyName);
            Console.ReadKey();
        }
        static void Domain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            AppDomain domain = sender as AppDomain;

            Console.WriteLine("void Domain_FirstChanceException");
            Console.WriteLine("Exception in domain " + domain.FriendlyName);
            Console.WriteLine("e.ExeptionMessage  " + e.Exception);
        }
    }
}
