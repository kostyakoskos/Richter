using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ExceptionsTryCatchFinally
{
    public sealed class SomeType
    {
        public void SomeMethod()
        {
            // Открытие файла
            FileStream fs = new FileStream("NEWFS", FileMode.Create);
            try
            {
                // Вывод частного от деления 100 на первый байт файла
                Console.WriteLine(100 / fs.ReadByte());
            }
            finally
            {
                // В блоке finally размещается код очистки, гарантирующий
                // закрытие файла независимо от того, возникло исключение
                // (например, если первый байт файла равен 0) или нет
                fs.Close();
                Console.WriteLine("Hello World!");
            }
        }
        private static void Demo1()
        {
            RuntimeHelpers.PrepareConstrainedRegions(); // Пространство имен
                                                        // System.Runtime.CompilerServices
            try
            {
                Console.WriteLine("In try");
            }
            finally
            {
                // Неявный вызов статического конструктора Type2
                Type2.M();
            }
        }
    }
    internal sealed class Type2
    {
        static Type2()
        {
            // В случае исключения M не вызывается
            Console.WriteLine("Type1's static ctor called");
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void M() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SomeType c = new();
            c.SomeMethod();

        }
    }
}
