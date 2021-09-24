using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

// MarshaByRefObject - abstract class. Разрешает доступ к объектам через домены приложений
// в приложениях поддерживающих удаленное взаимодействие
// маршалинг - кто-то сериализовал, кто-то другой будет сериализовать
// вся информация через адресное пр-во должна передоваться через сериализацию
namespace AppDomainTry
{
    class MyClass : MarshalByRefObject
    {
        public void Operation()
        {
            Console.WriteLine("Number of domain: " + AppDomain.CurrentDomain.Id);
            Console.WriteLine("instance: " + this.GetHashCode());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of domain main: " + AppDomain.CurrentDomain.Id);
            // Создаем domain, с названием таким-то. Сможем регулировать работу 2-го домена.
            AppDomain domain = AppDomain.CreateDomain("Secound Domain");

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;// название домена domain myclass
            string typeName = typeof(MyClass).FullName;

            // для управление экземплярами нашего класса
            ObjectHandle handle = domain.CreateInstance(assemblyName, typeName);

            MyClass instance = handle.Unwrap() as MyClass;

            Console.WriteLine("instance: " + instance.GetHashCode());

            // создан ли прозрачный прокси переходник
            // если что-то сделаем неправильно, не получится его развернуть
            Console.WriteLine("IsTransperentProxy " + RemotingServices.IsTransparentProxy(instance));

            instance.Operation();
            Console.ReadKey();
        }
    }
}
