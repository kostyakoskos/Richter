using System;
// indexator - можем оьращаться к элементам класса по индексу
namespace Indexator
{
    class Person
    {
        public string Name { get; set; }
    }
    class People
    {
        Person[] data;
        public People()
        {
            data = new Person[5];
        }
        //indexator
        public Person this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            People people = new();
            people[0] = new Person { Name = "Bob" };
            people[1] = new Person { Name = "John" };
            Person namePerson = people[1];
            Console.WriteLine("Hello World!");
        }
    }
}
