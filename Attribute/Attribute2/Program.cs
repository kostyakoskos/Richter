using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
// Атрибуты описывают, каким образом следует сериализовать данные, задают характеристики,
// используемые для усиления безопасности, и ограничивают оптимизацию JIT-компилятором,
// благодаря чему возможна простая отладка кода. 
//Атрибуты добавляют в программу метаданные. Метаданные — это сведения о типах, определенных в
//программе. Все сборки .NET содержат некоторый набор метаданных, описывающих типы и члены типов,
//определенные в этой сборке. Вы можете добавить пользовательские атрибуты, чтобы указать любую
//дополнительную информацию
// Вы можете применить один или несколько атрибутов ко всей сборке, к
// модулю или к более мелким элементам программы, например к классам и свойствам.
namespace Attribute2
{
    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        private string name;
        private string level;
        private bool reviewed;
        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewed = false;
        }
        public virtual string Name
        {
            get { return name; }
        }
        public virtual string Level
        {
            get { return level; }
        }
        public virtual bool Reviewed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
