using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
// appdomain cut in .netcore
namespace Domain
{

    class Myclass : MarshalByRefObject
    {
        public void Operation()
        {
            StringBuilder sb = new StringBuilder("appDomain from operation: ");
            sb.Append(AppDomain.CurrentDomain.Id);
            Console.WriteLine(sb);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("appDomain from main: ");
            sb.Append(AppDomain.CurrentDomain.Id);
            Console.WriteLine(sb);

            AppDomainSetup setup = new AppDomainSetup();

            AppDomain appDomain = AppDomain.CreateDomain("Secoud domain new");

            string assemlyName = Assembly.GetExecutingAssembly().GetName().Name;
            string type = typeof(Myclass).FullName;

            // создание объекта в другом(2) домене
            ObjectHandle h = appDomain.CreateInstance(assemlyName, type);

            Myclass instance = h.Unwrap() as Myclass;

            Console.WriteLine("instance {0} ", instance.GetHashCode());

            //Console.WriteLine("IsTransperentProxy(instance) : {0}", System.Runtime.Remoting.ObjectHandle. RemotingServices RemotingServices.IsTransparentProxy)

            instance.Operation();

            Console.WriteLine("Hello World!");
        }
    }
}
