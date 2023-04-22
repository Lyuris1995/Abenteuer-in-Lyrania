using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    internal class Schankwirtin
    {
        public static void WirtinText(string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }
    }
}
