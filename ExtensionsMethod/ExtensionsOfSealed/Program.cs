using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// extension методы нужны когда есть какой-то класс, к которому мы не имеем доступа
// Методы расширения находятся в статическом класс и должны быть статическими
namespace ExtensionsOfSealed
{
    static class MyExtension
    {
        // метод принимает this и тот класс, в который хотим добавить метод. Потом можно еще
        // передать какие-то параметры
        public static void Print(this DateTime dateTime)
        {
            Console.WriteLine(dateTime);
        }
        public static bool IsDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            return dateTime.DayOfWeek == dayOfWeek;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = DateTime.Now;

            d.Print();
            Console.WriteLine(d.IsDayOfWeek(DayOfWeek.Monday));
            Console.ReadKey();
        }
    }
}
