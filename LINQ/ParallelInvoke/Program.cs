using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

// Parallel for плохо исопльзовать, т.к. требует слишком много ресурсов. Надо использовать
// asParallel.
// Parallel.ForEach () обеспечивает последоватьельный дрступ к элементам, в отличие от asParallel
// asparallel это plinq

namespace ParallelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "first",
                "secound",
                "third",
                "fourth"
            };

            var list2 = new List<string>
            {
                "google.com",
                "fb.com",
                "google.com",
                "twitter.com"
            };

            var list3 = new List<string>
            {
                "Andrew",
                "Sergey",
                "Vasya",
                "Kolya"
            };

            //Ping ping = new Ping();
            //list2.AsParallel().ForAll(x => { Console.WriteLine(ping.Send(x).RoundtripTime); });

            //var v = new Ping().Send(list[0]).RoundtripTime;
            //Console.WriteLine(v);

            Parallel.For(0, 3, x => { Console.WriteLine(list[x]); });
            Parallel.ForEach(list, x => { Console.WriteLine(x); });

            Enumerable.Range(0, 3).AsParallel().ForAll(x => { Console.WriteLine(list[x]); });
            list.AsParallel().ForAll(x => { Console.WriteLine(x); });

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(list2[0]);
            Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);

            var newL = list3.Aggregate("Kolya", (x, y) => y.Length > x.Length ? y : x);
            newL.AsParallel().ForAll(x => { Console.WriteLine(x); });

            //List<string> a = new List<string>();
            //list2.AsParallel().ForAll(x => { a.Add(pingSender.Send(x).RoundtripTime.ToString()); });
            //list2.AsParallel().ForAll(x => { Console.WriteLine(x); });
        }
    }
}
