using System;

// В статическом конструкторе не нужно использовать уровень доступа(public, ...)
// В любом классе 1 статический констркутор, т.е. перегрузки статического конструктора нет
// статический конструктор не может принимать параметров
// статический конструктор выполняется всегда только 1 раз. Все равно сколько объектов класса
// создали
// статический конструктор вызывается для всех статических полей класса
// this нельзя использовать, т.к. this это указатель на экземпляр
// статический конструктор не требует создания экземпляра класса

namespace StaticConstructorClassField
{
    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Constructor Myclass");
        }
        static MyClass()
        {
            Console.WriteLine("Static Constructor Myclass");
        }
        public static void Foo()
        {
            Console.WriteLine("method Foo");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            MyClass c1 = new MyClass();
            MyClass c2 = new MyClass();
            MyClass c3 = new MyClass();
            MyClass.Foo();
            Console.ReadKey();
        }
    }
}
