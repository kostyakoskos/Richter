using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// можем загружать отдельные сборки как домены
namespace MultiDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain1 = AppDomain.CreateDomain("Domain1");
            AppDomain domain2 = AppDomain.CreateDomain("Domain2");
            try
            {
                domain1.ExecuteAssembly("App1.exe");
                domain2.ExecuteAssembly("App2.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("/n Main domen working " + AppDomain.CurrentDomain.FriendlyName);
            Console.ReadKey();
        }
    }
}
