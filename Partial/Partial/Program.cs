using System;
// partial работает со структурой данных, классом, интерфейсом, методы(отдельные ограничения)
// partial хорошо использовать когда изменили 1 файл, но при этом все файлы перекомпилировать не
// надо
namespace Partial
{
    internal sealed partial class Base
    {
        private String m_name;
        // Это объявление с определением частичного метода вызывается
        // перед изменением поля m_name
        partial void OnNameChanging(String value);
        public String Name
        {
            get { return m_name; }
            set
            {
                // Информирование класса о потенциальном изменении
                OnNameChanging(value.ToUpper());
                m_name = value; // Изменение поля
            }
        }
    }

    // Написанный программистом код, содержащийся в другом файле
    internal sealed partial class Base
    {
        // Это объявление с реализацией частичного метода вызывается перед тем,
        // как будет изменено поле m_name
        partial void OnNameChanging(String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base b = new();
            Console.WriteLine(b.Name);
            Console.WriteLine("Hello World!");
        }
    }
}
