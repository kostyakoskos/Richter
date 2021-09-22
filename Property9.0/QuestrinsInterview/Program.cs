using System;

namespace QuestrinsInterview
{
    public struct S : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }
    class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("Class A");
        }
    }
    class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("Class B");
        }
    }
    class C : A
    {
        public void ShowToConsole()
        {
            Console.WriteLine("ShowToConsole method");
        }
        public void Display()
        {
            Console.WriteLine("Display method");
        }
    }
    class Program
    {
        static void Operation(double a, double b, Action<double, double> actiondelegate)
        {
            if (a > b)
                actiondelegate(a, b);
        }

        static void Sum(double a, double b)
        {
            Console.WriteLine("Сумма чисел: " + (a + b));
        }

        static void Substract(double a, double b)
        {
            Console.WriteLine("Разность чисел: " + (a - b));
        }
        static void Main(string[] args)
        {
            //B obj1 = new A();
            //obj1.Foo();

            B obj2 = new B();
            obj2.Foo();// class B

            A obj3 = new B();
            Console.WriteLine(obj3.GetType());
            obj3.Foo();// A
            Console.WriteLine("---------------------");
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());
            Console.WriteLine("---------------------");

            C testName = new C();
            Action show = testName.ShowToConsole;
            show();
            Console.WriteLine("---------------------");
            Action showMethod = delegate () { testName.Display(); };
            showMethod();


            Console.WriteLine("---------------------");
            Action<double, double> actiondelegate = Sum;// Sum return void
            Operation(11.88, 6.55, actiondelegate);
            actiondelegate = Substract;
            Operation(100.22, 9.64, actiondelegate);
        }
    }
}
