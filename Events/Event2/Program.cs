using System;

namespace Event2
{
    public delegate void EventDelegate();// create event. not delegate because event! 
    public class MyClass
    {
        public event EventDelegate myEvent = null;

        public event EventDelegate MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();// срабатывают все методы подписаные на это событие
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

            instance.InvokeEvent();// вызвали все события у полписаных классов

            Console.WriteLine("---");

            instance.myEvent -= new EventDelegate(Handler1);

            instance.InvokeEvent();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}

