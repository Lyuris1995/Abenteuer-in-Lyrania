using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    internal class CharakterNautilus
    {
        public static void NautilusText(string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = originalColor;
        }
    }
}
