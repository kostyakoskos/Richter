using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records2
{
    //class Class1
    //{
    //}
    public record Cat(string Name, string Breed, string Color) : Pet(10)
    {
        public string Name { get; set; } = Name;
    }

    public record Pet(int Width); 
}
