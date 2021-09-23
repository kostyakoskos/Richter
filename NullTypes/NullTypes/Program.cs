using System;
using System.Runtime.InteropServices;

namespace NullTypes
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Nullable<T> where T : struct
    {
        // Эти два поля представляют состояние
        private Boolean hasValue; // Предполагается наличие null
        internal T value; // Предполагается, что все биты
                          // равны нулю
        public Nullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }
        public Boolean HasValue { get { return hasValue; } }
        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException(
                    "Nullable object must have a value.");
                }
                return value;
            }
        }

        public T GetValueOrDefault() { return value; }
        public T GetValueOrDefault(T defaultValue)
        {
            if (!HasValue) return defaultValue;
            return value;
        }
        public override Boolean Equals(Object other)
        {
            if (!HasValue) return (other == null);
            if (other == null) return false;
            return value.Equals(other);
        }
        public override int GetHashCode()
        {
            if (!HasValue) return 0;
            return value.GetHashCode();
        }
        public override string ToString()
        {
            if (!HasValue) return "";
            return value.ToString();
        }
        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // int? - nullable type. 
            Int32? a = 5;
            a = null;
            a++;
            a = 0;
            Int32? b = null;
            // Приведенная далее инструкция эквивалентна следующей:
            // x = (b.HasValue) ? b.Value : 123
            Int32 x = b ?? 123;// выведется 123, т.к. b null
            Console.WriteLine(x); // "123"

            //String filename = GetFilename ?? "Untitled";

            //String s = SomeMethod1() ?? SomeMethod2() ?? "Untitled";
            //// the same
            //String s;
            //var sm1 = SomeMethod1();
            //if (sm1 != null) s = sm1;
            //else
            //{
            //    var sm2 = SomeMethod2();
            //    if (sm2 != null) s = sm2;
            //    else s = "Untitled";
            //}

            // boxing null types
            // После упаковки Nullable<T> возвращается null или упакованный тип T
            Int32? n = null;
            Object o = n; // o равно null
            Console.WriteLine("o is null={0}", o == null); // "True"
            n = 5;
            o = n; // o ссылается на упакованный тип Int32
            Console.WriteLine("o's type={0}", o.GetType()); // "System.Int32"

            //unboxing null types
            // Создание упакованного типа Int32
            Object o1 = 5;
            // Распаковка этого типа в Nullable<Int32> и в Int32
            Int32? a1 = (Int32?)o1; // a = 5
            Int32 b1 = (Int32)o1; // b = 5
                                // Создание ссылки, инициализированной значением null
            o1 = null;
            // "Распаковка" ее в Nullable<Int32> и в Int32
            a1 = (Int32?)o1; // a = null
            //b1 = (Int32)o1; // NullReferenceException

            Int32? n2 = 5;
            Int32 result = ((IComparable)n2).CompareTo(5); // Компилируется
                                                          // и выполняется
            Console.WriteLine(result); // 0
        }
    }
}
