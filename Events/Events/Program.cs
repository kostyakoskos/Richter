using System;

namespace Events
{
    public delegate void EventDelegate();// create event. not delegate because event! 
    public delegate void EventDelegate1();
    public class MyClass
    {
        public event EventDelegate myEvent = null;
        public event EventDelegate myEvent1 = null;

        public void InvokeEvent()
        {
            myEvent.Invoke();// срабатывают все методы подписаные на это событие
        }
        public void InvokeEvent1()
        {
            myEvent1.Invoke();// срабатывают все методы подписаные на это событие
        }
    }
    class Program
    {
        static private void Handler1()
        {
            Console.WriteLine("Event 1");
        }
        static private void Handler2()
        {
            Console.WriteLine("Event 2");
        }
        
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.myEvent += new EventDelegate(Handler1);// подписали 1 класс
            instance.myEvent += Handler2;

            instance.myEvent1 += Handler2;

            instance.InvokeEvent();// вызвали все события у полписаных классов
            instance.InvokeEvent1();// вызвали все события у полписаных классов

            Console.WriteLine("---");

            instance.myEvent -= new EventDelegate(Handler1);

            instance.InvokeEvent();
            instance.InvokeEvent1();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
