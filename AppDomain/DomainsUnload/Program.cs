using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainsUnload
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("Secound Domain");
            // host domain - домен по умолчанию
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Child domain: " + domain.FriendlyName);

            // Убрать domain, мы его недавно создали
            AppDomain.Unload(domain);

            try
            {
                Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine("Child domain: " + domain.FriendlyName);
            }
            catch(AppDomainUnloadedException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
