using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

// так лучше не делать, т.к. код не устойчив к сбоям
// не можем ичпользовать "точки" в неуправляемом коде
namespace ClassSafehandler
{
    internal static class SomeType
    {
        [DllImport("Kernel32", CharSet = CharSet.Unicode, EntryPoint = "CreateEvent")]
        // Этот прототип неустойчив к сбоям
        private static extern IntPtr CreateEventBad(
        IntPtr pSecurityAttributes, Boolean manualReset,
        Boolean initialState, String name);
        // Этот прототип устойчив к сбоям
        [DllImport("Kernel32", CharSet = CharSet.Unicode, EntryPoint = "CreateEvent")]
        private static extern SafeWaitHandle CreateEventGood(
        IntPtr pSecurityAttributes, Boolean manualReset,
        Boolean initialState, String name);
        public static void SomeMethod()
        {
            IntPtr handle = CreateEventBad(IntPtr.Zero, false, false, null);
            SafeWaitHandle swh = CreateEventGood(IntPtr.Zero, false, false, null);
            Console.WriteLine("!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeType.SomeMethod();
            Console.ReadKey();
        }
    }
}
