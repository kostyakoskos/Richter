using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using System.Timers;
using System.Threading.Tasks;

namespace TimerGC
{
    class Program
    {
        public static void Main()
        {
            Timer t = new Timer(TimerCallback, null, 0, 200);
            //Console.WriteLine("wdw");
            Console.ReadLine();
        }
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }
    }
}
//using System;
//using System.Threading;

//public class Example
//{
//    public static void Main()
//    {
//        // Create an instance of the Example class, and start two
//        // timers.
//        Example ex = new Example();
//        ex.StartTimer(2);
//        ex.StartTimer(1);

//        Console.WriteLine("Press Enter to end the program.");
//        Console.ReadLine();
//    }

//    public void StartTimer(int dueTime)
//    {
//        Timer t = new Timer(new TimerCallback(TimerProc));
//        t.Change(dueTime, 0);
//    }

//    private void TimerProc(object state)
//    {
//        // The state object is the Timer object.
//        Timer t = (Timer)state;
//        t.Dispose();
//        Console.WriteLine("The timer callback executes.");
//    }
//}
