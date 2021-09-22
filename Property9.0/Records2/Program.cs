using System;

namespace Records2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat("Barsik", "british", "beauty");
            Cat c2 = new Cat("Barsik", "british", "beauty");

            Console.WriteLine(c1 == c2);

            // свойства неизменяемы
            //c1.Name = "swdw";

            // создаем новый экземпляр кота а не используем старый
            c1 = c1 with
            {
                Name = "Snezok",
            };
            Console.WriteLine(c1 == c2);
            c2.Name = "name from ctor";
            Console.WriteLine(c2);
            
        }
    }
}
