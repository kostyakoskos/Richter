using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// методы статического класса должны быть связаны, например class Math все ф-ции там тематические
// статические классы не имеют наследования и интерфейсов
// в статических классах нельзя реализовать полиморфизм
// в статических классах проблемы с dependency injection
// статические классы используют как всполмогательные классы, которые группируют по
// тематике методам с простым функционалом
// Плохо исопльзовать: класс студент. У каждого студента разная фамилия и тд. Так нельзя
namespace staticClass
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
