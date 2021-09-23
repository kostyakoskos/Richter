using System;
// интернирование строк нужно для того, чтобы правильнее использовать память. Есть строка, 
// от нее вычисляется хэш-функция и запичывается в таблицу. Т.е. вместо 2-х строк храним 1
// в хэш-табдице
// код с интернированием писать ПЛОХО
// пул строк- чтобы не было 2-х и более одинаковых строк
namespace InternString
{
    class Program
    {
        // такой метод плохой, т.к. лучше сравнить строки по хэш и если хэш одинаковый,
        // сказать что строки равны
        private static Int32 NumTimesWordAppearsEquals(String word, String[] wordlist)
        {
            Int32 count = 0;
            for (Int32 wordnum = 0; wordnum < wordlist.Length; wordnum++)
            {
                if (word.Equals(wordlist[wordnum], StringComparison.Ordinal))
                    count++;
            }
            return count;
        }
        private static Int32 NumTimesWordAppearsIntern(String word, String[] wordlist)
        {
            // В этом методе предполагается, что все элементы в wordlist
            // ссылаются на интернированные строки
            word = String.Intern(word);
            Int32 count = 0;
            for (Int32 wordnum = 0; wordnum < wordlist.Length; wordnum++)
            {
                if (Object.ReferenceEquals(word, wordlist[wordnum]))
                    count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            String s1 = "Hello";
            String s2 = "Hello";
            Console.WriteLine(Object.ReferenceEquals(s1, s2)); // Должно быть 'False'
            s1 = String.Intern(s1);
            s2 = String.Intern(s2);
            Console.WriteLine(Object.ReferenceEquals(s1, s2)); // 'True'
        }
    }
}
