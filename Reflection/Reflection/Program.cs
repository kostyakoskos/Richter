using System;
// Рефлексия позволяет изменять приватные поля класса
// Рефлексия или отражение - это специальный подход, который позволяет работать с типами данных
// которые мы используем в наших программах
namespace Reflection_1
{
    class MyClass
    {
        private string field = "123";
        public string Field { get { return field; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new();
            Console.WriteLine(instance.Field);
            Console.WriteLine("---");
            var type = instance.GetType();
            var field1 = type.GetField("field", System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic);// флаги нужны чтобы указать что это
            // экземплярное поле private
            field1.SetValue(instance, "Hello");// устанавливаем значение. Инкапсуляция не помеха

            Console.WriteLine(instance.Field);
            Console.WriteLine("---");


            // выводим все поля типа с помощью рефлексии.
            // Удобно когда много полей и все надо вывести
            var now = DateTime.Now;

            type = now.GetType();

            var props = type.GetProperties();
            foreach (var p in props)
            {
                Console.WriteLine("***");
                Console.WriteLine(p.Name + " --- " + p.GetValue(now));
            }
        }
    }
}
