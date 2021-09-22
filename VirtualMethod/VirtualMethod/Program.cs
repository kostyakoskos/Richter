using System;

namespace VirtualMethod
{
    public class Phone
    {
        //public void Dial()
        //{
        //    Console.WriteLine("Phone.Dial");
        //    // Выполнить действия по набору телефонного номера
        //}
        public void Dial()
        {
            Console.WriteLine("Phone.Dial");
            EstablishConnection();
            // Выполнить действия по набору телефонного номера
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("Phone.EstablishConnection");
            // Выполнить действия по установлению соединения
        }
    }
    public class BetterPhone : Phone
    {
        public new void Dial()
        {
            Console.WriteLine("BetterPhone.Dial");
            EstablishConnection();
            //base.Dial();
        }
        //protected new virtual void EstablishConnection()
        //{
        //    Console.WriteLine("BetterPhone.EstablishConnection");
        //    // Выполнить действия по набору телефонного номера
        //}
        // override переопределили
        protected override void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection");
            // Выполнить действия по установлению соединения
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BetterPhone b = new();
            b.Dial();
            //Console.WriteLine("Hello World!");
        }
    }
}
