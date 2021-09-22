using System;
using System.Text;

// только методы расширения. Надо писать this перед первым параметром
namespace ExtensionsMethod
{
    public static class StringBuilderExtensions
    {
        //public static Int32 IndexOf(StringBuilder sb, Char value)
        //{
        //    for (Int32 index = 0; index < sb.Length; index++)
        //        if (sb[index] == value) return index;
        //    return -1;
        //}
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (Int32 index = 0; index < sb.Length; index++)
                if (sb[index] == value) return index;
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Hello. My name is Jeff.");
            //Int32 index = StringBuilderExtensions.IndexOf(sb.Replace('.', '!'), '!');
            sb.Replace('.', '!');
            Int32 index = StringBuilderExtensions.IndexOf(sb, '!');
            Int32 index1 = sb.Replace('.', '!').IndexOf('!');
        }
    }
}
