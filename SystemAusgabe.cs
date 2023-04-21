using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    internal class SystemAusgabe
    {
        public static void Anweisung(string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }
    }
}
