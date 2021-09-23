using System;
using System.Text;
// эффективный способ работа со строками. concat не нужен
// stringbuilder это изменяемая строка в отличие от string
// при дополнеии строки новая не создается
namespace EffectiveStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            String s = sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").
             Replace(' ', '-').Remove(4, 3).ToString();
            Console.WriteLine(s); // "Jeff-Richter"

        }
    }
}
