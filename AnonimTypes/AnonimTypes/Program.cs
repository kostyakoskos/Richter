using System;
using System.IO;
using System.Linq;

namespace AnonimTypes
{
    class User
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //User tom = new User { Name = "Tom" };
            //int age = 34;
            //var student = new { tom.Name, age }; // инициализатор с проекцией
            //Console.WriteLine(student.Name);
            //Console.WriteLine(student.age);
            //tom.Name = "One";
            //Console.WriteLine(tom.Name);
            //Console.WriteLine(student.Name);
            //Console.WriteLine(student.age);

            //var o1 = new { Name = "Jeff", Year = 1964 };

            //var people = new[] {
            //    o1, // См. ранее в этом разделе
            //    new { Name = "Kristin", Year = 1970 },
            //    new { Name = "Aidan", Year = 2003 },
            //    new { Name = "Grant", Year = 2008 }
            //};

            //foreach(var person in people)
            //    Console.WriteLine("Person={0}, Year={1}", person.Name, person.Year);

            String myDocuments =
 Environment.GetFolderPath(Environment.SpecialFolder.Desktop);// myDocuments
            var query =
             from pathname in Directory.GetFiles(myDocuments)
             let LastWriteTime = File.GetLastWriteTime(pathname)
             where LastWriteTime > (DateTime.Now - TimeSpan.FromDays(7))
             orderby LastWriteTime
             select new { Path = pathname, LastWriteTime };
            foreach (var file in query)
                Console.WriteLine("LastWriteTime={0}, Path={1}",
                file.LastWriteTime, file.Path);

            Console.Read();
        }
    }
}
