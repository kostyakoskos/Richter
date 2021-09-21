using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //override ToString to return the person's FirstName LastName Age
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var list = new List<string>
            {
                "first",
                "secound",
                "third",
                "fourth"
            };
            var list2 = new List<string>
            {
                "1",
                "2",
                "3",
                "4"
            };

            //Array.Reverse(array);
            list.Reverse();// it's not Linq because generic
            foreach (var o in list)
            {
                Console.WriteLine(o);
            }

            var newlist = list2.Union(list);
            foreach (var o in newlist)
            {
                Console.WriteLine(o);
            }

            //var l = new List<string>();
            //foreach(string line in list)
            //{
            //    if(line.Contains("e"))
            //    {
            //        l.Add(line);
            //    }
            //}

            // the same but using LINQ
            var l = list.Where(x => x.Contains("e"));
            int i = 1;
            var l1 = list.Select(x => $"{i++} {x}");
            var l2 = list.OrderByDescending(x => x);

            Console.WriteLine("---");
            foreach (var o in l)
            {
                Console.WriteLine(o);
            }
            foreach (var o in l2)
            {
                Console.WriteLine(o);
            }

            var people = new List<Person>()
        {
            new Person("Bill", "Smith", 41),
            new Person("Sarah", "Jones", 22),
            new Person("Stacy","Baker", 21),
            new Person("Vivianne","Dexter", 19 ),
            new Person("Bob","Smith", 49 ),
            new Person("Brett","Baker", 51 ),
            new Person("Mark","Parker", 19),
            new Person("Alice","Thompson", 18),
            new Person("Evelyn","Thompson", 58 ),
            new Person("Mort","Martin", 58),
            new Person("Eugene","deLauter", 84 ),
            new Person("Gail","Dawson", 19 ),

        };

            var l3 = people.Where(x => x.FirstName.StartsWith("B"));
            Console.WriteLine("---");
            foreach (var o in l3)
            {
                Console.WriteLine(o.FirstName);
            }

            Console.ReadKey();
        }
    }
}
