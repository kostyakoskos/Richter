using System;
using System.IO;
// dispose не освобождает память в куче. Освобождение памяти в куче происходит тольео при сборке мусора
namespace DisposeF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание байтов для записи во временный файл
            Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 4, 5 };
            // Создание временного файла
            FileStream fs = new FileStream("Temp.dat", FileMode.Create);
            // Запись байтов во временный файл
            try
            {
                fs.Write(bytesToWrite, 0, bytesToWrite.Length);
            }
            // Явное закрытие файла после записи
            // Если файл не закроем, будет исклчение при вызове delete, 
            // т.к. нельзя удалить открытый файл
            finally
            {
                fs.Dispose();
            }

            // тоже самое через using. Только ещё catch будет
            // Создание временного файла
            using (FileStream fs1 = new FileStream("Temp.dat", FileMode.Create))
            {
                // Запись байтов во временный файл
                fs1.Write(bytesToWrite, 0, bytesToWrite.Length);
            }

            // Удаление временного файла
            File.Delete("Temp.dat"); // Теперь эта инструкция
                                     // всегда остается работоспособной
        }
    }
}
