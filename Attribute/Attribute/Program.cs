using System;
using System.Reflection;

//[assembly: AssemblyVersion("4.3.2.1")] // Применяется к сборке
//[module: SomeAttr] // Применяется к модулю

namespace Attribute
{
    //[type: SomeAttr] // Применяется к типу
    //internal sealed class SomeType<[typevar: SomeAttr] T>
    //{ // Применяется
    //  // к переменной обобщенного типа
    //    [field: SomeAttr] // Применяется к полю
    //    public Int32 SomeField = 0;
    //    [return: SomeAttr] // Применяется к возвращаемому значению
    //    [method: SomeAttr] // Применяется к методу
    //    public Int32 SomeMethod(
    //    [param: SomeAttr] // Применяется к параметру
 //Int32 SomeParam)
 //       { return SomeParam; }
 //       [property: SomeAttr] // Применяется к свойству
 //       public String SomeProp
 //       {
 //           [method: SomeAttr] // Применяется к механизму доступа get
 //           get { return null; }
 //       }
 //       [event: SomeAttr] // Применяется к событиям
 //       [field: SomeAttr] // Применяется к полям, созданным компилятором
 //       [method: SomeAttr] // Применяется к созданным
 //                          // компилятором методам add и remove
 //       public event EventHandler SomeEvent;
 //   }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
