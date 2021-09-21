//using System;
//using System.Collections.Generic;
//using System.Xml.Serialization;

//namespace Serialization
//{
//    struct Point
//    {
//        public Point(int X, int Y)
//        {
//            this.X = X;
//            this.Y = Y;
//        }
//        public int X { get; set; }
//        public int Y { get; set; }
//    }
//    class MyClass
//    {
//        private string id = "button";
//        private int size = 10;
//        private Point position = new Point(20, 20);
//        private string password = "123";
//        private List<string> items = new List<string>();

//        [XmlAttribute("SerialId")]
//        public string Id { get { return id; } set { id = value; } }

//        [XmlAttribute("Lenght")]
//        public int Size { get { return size; } set { size = value; } }

//        [XmlElement("Pos")]
//        public Point Position { get { return position; } set { position = value; } }

//        //non serialize
//        [XmlIgnore]
//        public string Password { get { return password; } set { password = value; } }

//        [XmlArray("List")]
//        [XmlArrayItem("Element")]
//        public List<string> Items { get { return items; } set { items = value; } }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    // в этом примере 2 поля, 1 из которых не нужно сериализовывать. 
    // Сериализация объекта выполнится правильно, а вот при дессириализции m_area будет 0,
    // т.к. это поле не было сериализовано. и мы его пытаемся десериализовать.
    [Serializable]
    internal class Circle
    {
        public Double m_radius;
        [NonSerialized]
        public Double m_area;
        public Circle(Double radius)
        {
            m_radius = radius;
            m_area = Math.PI * m_radius * m_radius;
        }
        // метод когда 1 поле не сериализовано, без него никак
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            m_area = Math.PI * m_radius * m_radius;
        }
    }
    internal static class QuickStart
    {
        public static void Main()
        {
            Circle c = new Circle(10);
            Stream stream1 = SerializeToMemory(c);
            stream1.Position = 0;
            c = null;
            c = (Circle)DeserializeFromMemory(stream1);
            Console.WriteLine(c.m_radius + " " + c.m_area);
            Console.WriteLine("---");
            // Создание графа объектов для последующей сериализации в поток
            var objectGraph = new List<String> { "Jeff", "Kristin", "Aidan", "Grant" };
            Stream stream = SerializeToMemory(objectGraph);
            // Обнуляем все для данного примера
            stream.Position = 0;
            objectGraph = null;
            // Десериализация объектов и проверка их работоспособности
            objectGraph = (List<String>)DeserializeFromMemory(stream);
            foreach (var s in objectGraph) Console.WriteLine(s);
        }
        private static MemoryStream SerializeToMemory(Object objectGraph)
        {
            // Конструирование потока, который будет содержать
            // сериализованные объекты
            MemoryStream stream = new MemoryStream();
            // Задание форматирования при сериализации
            BinaryFormatter formatter = new BinaryFormatter();
            // Заставляем модуль форматирования сериализовать объекты в поток
            formatter.Serialize(stream, objectGraph);
            // Возвращение потока сериализованных объектов вызывающему методу
            return stream;
        }
        private static Object DeserializeFromMemory(Stream stream)
        {
            // Задание форматирования при сериализации
            BinaryFormatter formatter = new BinaryFormatter();
            // Заставляем модуль форматирования десериализовать объекты из потока
            return formatter.Deserialize(stream);
        }
    }
}