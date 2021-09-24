using System;

namespace GCGeneration
{
    class UserInfo
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public UserInfo(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("БАЗОВАЯ ИНФОРМАЦИЯ О СИСТЕМЕ: \n" +
                "-----------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"Операционная система: {0}
Версия .NET Framework: {1}", Environment.OSVersion, Environment.Version);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИНФОРМАЦИЯ О СБОРКЕ МУСОРА: \n" +
                "---------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"Количество байт в куче: {0}
Максимальное количество поддерживаемых поколений объектов: {1}"
                , GC.GetTotalMemory(false), GC.MaxGeneration + 1);

            UserInfo user1 = new UserInfo("Alex", 26);
            Console.WriteLine("Поколение объекта user1: " + GC.GetGeneration(user1));

            for (int i = 0; i < 50000; i++)
            {
                UserInfo user = new UserInfo("Dm", 27);
            }

            // Намеренно вызовем сборку мусора
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("\nсборка мусора ...\n");

            Console.WriteLine("Теперь поколение объекта user1: " + GC.GetGeneration(user1));

            Console.ReadLine();
        }
    }
}
