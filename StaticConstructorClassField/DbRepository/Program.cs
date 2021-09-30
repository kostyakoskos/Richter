using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// добавляем общее статическое поле - строка подключения к бд
// строку подключения надо хранить в конфигурации

// создаем статический конструктор, вызывается всего 1 раз.
// Если обычный коструктор - при создании кажого экземпляра
// статический конструктор будет вызван 1 раз и больше никогда. 
// больше не выделяем память
namespace DbRepository
{
    class Db
    {
        //private static string connectionString;
        public static string connectionString;
        // создаем статический конструктор, вызывается всего 1 раз.
        // Если обычный коструктор - при создании кажого экземпляра
        static Db()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            connectionString = configurationManager.GetConnectionString();
        }
        public void GetData()
        {
            Console.WriteLine("Constr = " + connectionString);
        }
    }
    class ConfigurationManager
    {
        public string GetConnectionString()
        {
            return "localDb";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Db f = new Db();
            f.GetData();
        }
    }
}
