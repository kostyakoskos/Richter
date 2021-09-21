using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fields
{
    //public sealed class SomeType
    //{
    //    public static readonly Int32 MaxValue = 50;

    //    public static readonly Random s_random = new Random();

    //    private static Int32 s = 0;

    //    public readonly String PathName = "Utilied";

    //    private System.IO.FileStream m_fs;

    //    public SomeType(string pathName)
    //    {
    //        this.PathName = pathName;
    //    }

    //    public string DoSomething()
    //    {
    //        s = s + 1;
    //        return PathName;
    //    }
    //}
    public static class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}
        private static Int32 s_n = 0;
        private static void M(Int32 x = 9, String s = "A", DateTime dt = default(DateTime),
            Guid guid = new Guid())
        {
            Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
        }
        public static void Main()
        {
            // 1. Аналогично: M(9, "A", default(DateTime), new Guid());
            M();
            // 2. Аналогично: M(8, "X", default(DateTime), new Guid());
            M(8, "X");
            // 3. Аналогично: M(5, "A", DateTime.Now, Guid.NewGuid());
            M(5, guid: Guid.NewGuid(), dt: DateTime.Now);
            // 4. Аналогично: M(0, "1", default(DateTime), new Guid());
            M(s_n++, s_n++.ToString());
            // 5. Аналогично: String t1 = "2"; Int32 t2 = 3;
            // M(t2, t1, default(DateTime), new Guid());
            M(s: (s_n++).ToString(), x: s_n++);
        }
    }
}
