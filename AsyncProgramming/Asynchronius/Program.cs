using System;
using System.Threading.Tasks;

namespace Asynchronius
{
    class Program
    {
        public async Task DoAsync()
        {
            Console.WriteLine("Before await");

            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("Between awaits");

            await Task.Delay(TimeSpan.FromSeconds(1));

            Console.WriteLine("After await");
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
        }
    }
}
