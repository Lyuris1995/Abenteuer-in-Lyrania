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
            string bauerEntscheidung = "";

            /*while (Turn < 20)
            {*/
            //Turn++; Gold++;
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            HUD(playerName, Location, Turn, Gold);
            Console.SetCursorPosition(currentLeft, currentTop);
            //}

            Console.Title = "Abenteuer in Lyrania";

            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            PlayerCharacter();
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemDialog("Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.WriteLine("Du siehst einen älteren Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            BauerDialog("\"Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen,\n ansonsten geh runter von mei'm Feld!\"", "green", out bauerEntscheidung);

            EndGame();
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

        static void BauerDialog(string message, string color, out string entscheidung)
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
                    Gold += 1;
                    entscheidung = "JA";
                    //UpdateHUD(Gold);
                    break;
                }
                else if (input == "NEIN")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dagegen entschieden dem Bauern zu helfen.");
                    Console.ResetColor();
                    entscheidung = "NEIN";
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Antworte bitte mit Ja oder Nein!");
                    Console.ResetColor();
                }
            }

            if (entscheidung == "JA")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vielen Dank, dass du mir geholfen hast. Is' nich' selbstverständlich, weißte? Ich war ziemlich gemein zu dir,\ndas tut mir Leid. Würdest du mir verraten, wo du her kommst?");
                Console.ResetColor();
            }
            else if (entscheidung == "NEIN")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dann mach dass du verschwindest! Ich hab' keine Zeit für so'n faulen Typ wie dich!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Der Bauer verscheucht dich mit seiner Mistgabel. Du rennst so schnell wie du kannst, bis du in einer Höhle ankommst.\n Als du kurz verschnauft hast bemerkst du, dass überall an den Höhlenwänden Blaue Steine leuchten.");
                Console.ResetColor();
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

        /*public static void UpdateHUD(int gold)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.Write($"Gold: {gold}");
            Console.ResetColor();
        }*/

        public static void EndGame()
        {
            Console.WriteLine($"Herzlichen Glückwunsch, {playerName}, dein Abenteuer ist zuende. Du hast {Gold} Gold gesammelt!");
            Console.WriteLine("Drücke Enter zum beenden.");
        }
    }
}
