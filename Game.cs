using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    public static class Game
    {
        static string playerName = "";
        static string Location = "Startzone";
        static int Turn = 0;
        static int Gold = 0;

        public static void StartGame()
        {
            string Location = "Startzone";
            int Turn = 0;
            int Gold = 0;

            while (Turn < 20)
            {
                Turn++; Gold++;
                HUD(playerName, Location, Turn, Gold);
            }

            Console.Title = "Abenteuer in Lyrania";

            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            PlayerCharacter();
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemDialog("Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.WriteLine("Du siehst einen älteren Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            BauerDialog("\"Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen,\n ansonsten geh runter von mei'm Feld!\"", "green");

        }

        static void PlayerCharacter()
        {
            Console.WriteLine("Bitte gib deinen Namen ein: ");
            playerName = Console.ReadLine();
            Console.WriteLine($"Deine Name lautet nun: {playerName}");
            HUD(playerName, Location, Turn, Gold);
        }

        static void SystemDialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void BauerDialog(string message, string color)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();

            while (true)
            {
                string input = "";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Du musst nun deine erste Entscheidung treffen, {playerName}. Willst du dem Bauern helfen? ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                input = Console.ReadLine().ToUpper();
                Console.ResetColor();

                if (input == "JA")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dafür entschieden dem Bauern zu helfen. Du erhältst eine Goldmünze!");
                    Console.ResetColor();
                    break;
                }
                else if (input == "NEIN")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dagegen entschieden dem Bauern zu helfen.");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Antworte bitte mit Ja oder Nein!");
                    Console.ResetColor();
                }
            }
        }


        public static void HUD(string playerName, string location, int turn, int gold)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    " + playerName);
            Console.ResetColor();
            Console.Write(" :: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(location);
            Console.ResetColor();
            Console.Write(" :: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("turn " + turn + " /20");
            Console.ResetColor();
            Console.Write(" :: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(gold + " gold\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================================\n\n\n\n");
            Console.ResetColor();
        }
    }
}
