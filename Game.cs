using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    public static class Game
    {
        static string playerName = "";
        static string Location = "Startzone";
        static string nautilusName = "Nautilus";
        static int Gold = 0;

        public static void StartGame()
        {
            string Location = "Startzone";
            int Gold = 0;
            List<string> Inventar = new List<string>();
            string bauerEntscheidung = "";

            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            HUD(playerName, Location, Inventar, Gold);
            Console.SetCursorPosition(currentLeft, currentTop);


            Console.Title = "Abenteuer in Lyrania";

            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            PlayerCharacter(Inventar);
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemDialog("Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.WriteLine("Du siehst einen älteren Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            BauerDialog("\"Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen,\n ansonsten geh runter von mei'm Feld!\"", "green", out bauerEntscheidung, Inventar);
            


            EndGame();
        }

        static void PlayerCharacter(List<string> Inventar)
        {
            Console.WriteLine("Bitte gib deinen Namen ein: ");
            playerName = Console.ReadLine();
            Console.WriteLine($"Deine Name lautet nun: {playerName}");
            if (playerName == "Lyuris")
            {
                Inventar.Add("Flügel der Reinheit");
            }
            HUD(playerName, Location, Inventar, Gold);
        }

        static void SystemDialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void BauerDialog(string message, string color, out string entscheidung, List<string> Inventar)
        {
            CharakterNautilus.NautilusText(message);

            while (true)
            {
                string input = "";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Du musst nun deine erste Entscheidung treffen, {playerName}. Willst du dem Bauern helfen? ");
                Console.ResetColor();
                input = Console.ReadLine().ToUpper();
                Console.ResetColor();

                if (input == "JA")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dafür entschieden dem Bauern zu helfen. Du erhältst eine Goldmünze!");

                    Console.ResetColor();
                    Gold += 1;
                    entscheidung = "JA";
                    UpdateHUD(playerName, Location, Inventar, Gold);
                    break;
                }
                else if (input == "NEIN")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dagegen entschieden dem Bauern zu helfen.");
                    Console.ResetColor();
                    entscheidung = "NEIN";
                    Inventar.Add("Schwert");
                    Location = "Frosthöhle";
                    UpdateHUD(playerName, Location, Inventar, Gold);
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
                CharakterNautilus.NautilusText("Vielen Dank, dass du mir geholfen hast. Is' nich' selbstverständlich, weißte? Ich war ziemlich gemein zu dir,\ndas tut mir Leid. Würdest du mir verraten, wo du her kommst?");
                SystemAusgabe.Anweisung("Möchtest du dem Bauern verraten, wo du her kommst?");
                string input = Console.ReadLine().ToUpper();
                if (input == "JA")
                {
                    SystemAusgabe.Anweisung("Du erzählst dem Bauern alles, deinen Namen, wo du ursprünglich herkommst und dass du keine Ahnung hast,\n wie du hier her gekommen bist, außer, dass da ein Wesen mit Flügeln war.");
                    CharakterNautilus.NautilusText($"m-m-m-Moment, langsam jetz'! Du heißt {playerName}, kommst aus einem Land namens \"Deutschland\" und wurdest von einem Wes'n mit Flügeln hergebracht?\nDas klingt alles ziemlich aufregend und ich hab' keine Ahnung, was das alles bedeutet. Aber du hast mir geholfen und mir vertraut,\ndafür Schulde ich dir was. Wenn du möchtest, darfst du gerne hier schlafen. Oh ja, mein Name is' übrigens {nautilusName}.\nFreut mich, dich kennen zu lernen!");
                }
                else if (input == "NEIN")
                {
                    SystemAusgabe.Anweisung("Du sagst lediglich deinen Namen und dass du nicht genau weißt, wo du bist und wie du hier her gekommen bist.");
                    CharakterNautilus.NautilusText($"Oh, {playerName} heißt du also? Komischer Name, den hab' ich hier noch nie gehört. Wie dem auch sei,\ndu hast mir sehr geholfen, dafür Schuld' ich dir was.\nDu hast zwar schon 'n Gold von mir bekommen, aber das reicht nich', um dich zu vergüt'n.\nWenn du möchtest, darfst du hier schlaf'n und dich ausruh'n, was zu Ess'n kann ich dir auch anbiet'n! Mein Name is' übrigens {nautilusName}.");
                }
            }
            else if (entscheidung == "NEIN")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dann mach dass du verschwindest! Ich hab' keine Zeit für so'n faulen Typ wie dich!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Der Bauer verscheucht dich mit seiner Mistgabel. Du rennst so schnell wie du kannst, bis du in einer Höhle ankommst.\n Als du kurz verschnauft hast bemerkst du, dass überall an den Höhlenwänden Blaue Steine leuchten.");
                Console.ResetColor();
                Console.WriteLine("Du findest ein Schwert auf dem Boden der Höhle!");
                
            }
        }

        public static void HUD(string playerName, string location, List<string> Inventar, int gold)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=================================================================================");
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
            Console.Write(string.Join(", ", Inventar));
            Console.ResetColor();
            Console.Write(" :: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(gold + " gold\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=================================================================================\n\n\n\n");
            Console.ResetColor();
            Console.CursorVisible = true;
        }

        public static void UpdateHUD(string playerName, string Location, List<string> Inventar, int Gold)
        {
            int currentLeft = Console.WindowLeft + Console.CursorLeft;
            int currentTop = Console.WindowTop + Console.CursorTop;
            HUD(playerName, Location, Inventar, Gold);
        }

        public static void EndGame()
        {
            Console.WriteLine($"Herzlichen Glückwunsch, {playerName}, dein Abenteuer ist zuende. Du hast {Gold} Gold gesammelt!");
            Console.WriteLine("Drücke Enter zum beenden.");
        }
    }
}
