using System;

namespace Property9._0
{
    //public record Person(string FirstName, string LastName);
    // new type of property 9. init new in 9
    public record Person
    {
        // ?
        //public Person(string f, string l)
        //{
        //    FirstName = f;
        //    LastName = l;
        //}
        public string FirstName { get; init; }
        public string LastName { get; init; }
    };

    class PersonClass
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
    public record PhoneNumber
    {
        public string number { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            // The same as: from c#9
            // Person p = new Person()
            Person p = new()
            {
                FirstName = "Maks",
                LastName = "Ber",
            };
            //PersonClass p1 = new PersonClass
            //{
            //    FirstName = "Maks",
            //    LastName = "Ber",
            //};
            Console.WriteLine(p);
            //Console.WriteLine(p);
            //Person p2 = new("John", "Smit");
            var phoneNum = new string[2];
            //PhoneNumber ph = new("John", "Kan", phoneNum);

            
        }
    }
}
