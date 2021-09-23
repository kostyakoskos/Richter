using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Generic
{
    //   [Serializable]
    //   public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>,
    //IList, ICollection, IEnumerable
    //   {
    //       public List();
    //       public void Add(T item);
    //       public Int32 BinarySearch(T item);
    //       public void Clear();
    //       public Boolean Contains(T item);
    //       public Int32 IndexOf(T item);
    //       public Boolean Remove(T item);
    //       public void Sort();
    //       public void Sort(IComparer<T> comparer);
    //       public void Sort(Comparison<T> comparison);
    //       public T[] ToArray();
    //       public Int32 Count { get; }
    //       public T this[Int32 index] { get; set; }
    //   }
    // Класс для оценки времени выполнения операций
    internal sealed class OperationTimer : IDisposable
    {
        private Stopwatch m_startTime, m_stopwatch;
        private String m_text = "1";
        private int m_collectionCount;
        
        public OperationTimer(String text)
        {
            PrepareForOperation();
            m_text = text;
            m_collectionCount = GC.CollectionCount(0);
            // Эта команда должна быть последней в этом методе
            // для максимально точной оценки быстродействия
            m_startTime = Stopwatch.StartNew();
        }
        public void Dispose()
        {
            //Console.WriteLine("{0}  {1}", (m_stopwatch.Elapsed),
            //GC.CollectionCount(0));
        }
        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
    internal sealed class Node<T>
    {
        public T m_data;
        public Node<T> m_next;
        public Node(T data) : this(data, null)
        {
        }
        public Node(T data, Node<T> next)
        {
            m_data = data; m_next = next;
        }
        public override String ToString()
        {
            return m_data.ToString() +
            ((m_next != null) ? m_next.ToString() : null);
        }
    }
    class Program
    {
        public static void SameDataLinkedList()
        {
            Node<Char> head = new Node<Char>('C');
            head = new Node<Char>('B', head);
            head = new Node<Char>('A', head);
            Console.WriteLine(head.ToString()); // Выводится "ABC"
        }
        static void Main(string[] args)
        {
            ValueTypePerfTest();
            ReferenceTypePerfTest();
            Program.SameDataLinkedList();
        }
        private static void ValueTypePerfTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n); // Без упаковки
                    Int32 x = l[n]; // Без распаковки
                }
                l = null; // Для удаления в процессе уборки мусора
            }
            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n); // Упаковка
                    Int32 x = (Int32)a[n]; // Распаковка
                }
                a = null; // Для удаления в процессе уборки мусора
            }
        }
        private static void ReferenceTypePerfTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<String>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X"); // Копирование ссылки
                    String x = l[n]; // Копирование ссылки
                }
                l = null; // Для удаления в процессе уборки мусора
            }
            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add("X"); // Копирование ссылки
                    String x = (String)a[n]; // Проверка преобразования
                } // и копирование ссылки
                a = null; // Для удаления в процессе уборки мусора}
            }
        }
      
    }
}
