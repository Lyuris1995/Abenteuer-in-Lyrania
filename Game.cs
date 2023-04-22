using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    public static class Game
    {
        static public string playerName = "";
        static public string Location = "Startzone";
        static public string nautilusName = "Nautilus";
        static public string reiseZiel = "";
        static public int Gold = 0;

        public static void StartGame()
        {
            string Location = "Startzone";
            int Gold = 0;
            List<string> Inventar = new List<string>();
            string bauerEntscheidung = "";

            Console.Title = "Abenteuer in Lyrania";

            UpdateHUD(3, Inventar);
            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            HUD(playerName, Location, Inventar, Gold);
            PlayerCharacter(Inventar);
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemDialog("Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.WriteLine("Du siehst einen älteren Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            NautilusDialog("\"Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen,\n ansonsten geh runter von mei'm Feld!\"", out bauerEntscheidung, Inventar);
            if (bauerEntscheidung == "NEIN")
            {
                FrostHöhle(Inventar);
            }
            WeiteresVorgehen(Inventar);
            



            EndGame();
        }

        static void PlayerCharacter(List<string> Inventar)
        {
            Console.WriteLine("Bitte gib deinen Namen ein: ");
            playerName = Console.ReadLine();
            HUD(playerName, Location, Inventar, Gold);
            Console.WriteLine($"Deine Name lautet nun: {playerName}");
            if (playerName == "Lyuris")
            {
                Inventar.Add("Flügel der Reinheit");
            }
        }

        static void SystemDialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void NautilusDialog(string message, out string entscheidung, List<string> Inventar)
        {
            CharakterNautilus.NautilusText(message);

            while (true)
            {
                SystemAusgabe.Anweisung($"Du musst nun deine erste Entscheidung treffen, {playerName}. Willst du dem Bauern helfen? ");;
                string input = UserInput();
                UpdateHUD(3, Inventar);

                if (input == "JA")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Du hast dich dafür entschieden dem Bauern zu helfen. Du erhältst eine Goldmünze!");

                    Console.ResetColor();
                    Gold += 1;
                    entscheidung = "JA";
                    HUD(playerName, Location, Inventar, Gold);
                    break;
                }
                else if (input == "NEIN")
                {
                    SystemAusgabe.Anweisung("Du hast dich dagegen entschieden dem Bauern zu helfen.");
                    entscheidung = "NEIN";
                    HUD(playerName, Location, Inventar, Gold);
                    break;
                }
                else
                {
                    SystemAusgabe.Anweisung("Antworte bitte mit Ja oder Nein!");
                }
            }

            if (entscheidung == "JA")
            {
                CharakterNautilus.NautilusText($"Komm, wir gehen erst mal in meine Hütte. Mein Name ist übrigens {nautilusName}");
                Location = "Nautilus' Hütte";
                HUD(playerName, Location, Inventar, Gold);
                CharakterNautilus.NautilusText("Vielen Dank, dass du mir geholfen hast. Is' nich' selbstverständlich, weißte? Ich war ziemlich gemein zu dir,\ndas tut mir Leid. Würdest du mir verraten, wo du her kommst?");
                SystemAusgabe.Anweisung("Möchtest du dem Bauern verraten, wo du her kommst?");
                string input = Console.ReadLine().ToUpper();
                if (input == "JA")
                {
                    SystemAusgabe.Anweisung("Du erzählst dem Bauern alles, deinen Namen, wo du ursprünglich herkommst und dass du keine Ahnung hast,\n wie du hier her gekommen bist, außer, dass da ein Wesen mit Flügeln war.");
                    CharakterNautilus.NautilusText($"m-m-m-Moment, langsam jetz'! Du heißt {playerName}, kommst aus einem Land namens \"Deutschland\" und wurdest von einem Wes'n mit Flügeln hergebracht?\nDas klingt alles ziemlich aufregend und ich hab' keine Ahnung, was das alles bedeutet. Aber du hast mir geholfen und mir vertraut,\ndafür Schulde ich dir was. Wenn du möchtest, darfst du gerne hier schlafen.\nFreut mich, dich kennen zu lernen!");
                }
                else if (input == "NEIN")
                {
                    SystemAusgabe.Anweisung("Du sagst lediglich deinen Namen und dass du nicht genau weißt, wo du bist und wie du hier her gekommen bist.");
                    CharakterNautilus.NautilusText($"Oh, {playerName} heißt du also? Komischer Name, den hab' ich hier noch nie gehört. Wie dem auch sei,\ndu hast mir sehr geholfen, dafür Schuld' ich dir was.\nDu hast zwar schon 'n Gold von mir bekommen, aber das reicht nich', um dich zu vergüt'n.\nWenn du möchtest, darfst du hier schlaf'n und dich ausruh'n, was zu Ess'n kann ich dir auch anbiet'n!");
                }
            }
            else if (entscheidung == "NEIN")
            {
                CharakterNautilus.NautilusText("Dann mach dass du verschwindest! Ich hab' keine Zeit für so'n faulen Typ wie dich!");
                SystemAusgabe.Anweisung("Der Bauer verscheucht dich mit seiner Mistgabel. Du rennst so schnell wie du kannst, bis du in einer Höhle ankommst.");      
            }
        }

        static void FrostHöhle(List<string> Inventar)
        {
            Location = "Frosthöhle";
            HUD(playerName, Location, Inventar, Gold);
            SystemAusgabe.Anweisung("Du befindest dich nun vor einer Höhle mit Blauen Steinen, die überall an den Wänden hängen. Was möchtest du tun?");
            bool restartSwitch = true;

            while(restartSwitch)
            {
                string input = UserInput();
                switch (input) 
                {
                    case "ERKUNDEN":
                    case "UMSEHEN":

                        if (!Inventar.Contains("Kalter Stein"))
                        {
                            SystemAusgabe.Anweisung("In der Höhle sind viele leuchtende Steine. Als du einen berührst merkst du,\ndass diese sehr Kalt sind! Du steckst einen dieser Steine ein, man kann ja nie wissen...");
                            Inventar.Add("Kalter Stein");
                            HUD(playerName, Location, Inventar, Gold);
                        }
                        else
                        {
                            SystemAusgabe.Anweisung("Hier liegen noch mehr dieser kalten Steine herum. Es wäre unnötig, noch mehr mit zu nehmen.");
                        }

                        SystemAusgabe.Anweisung("Möchtest du dich noch weiter in der Höhle umschauen?");
                        input = UserInput();
                        switch (input)
                        {
                            case "JA":

                                if (!Inventar.Contains("Baal's Amulett"))
                                {
                                    SystemAusgabe.Anweisung("An der Höhlendecke leuchtet etwas Rotes.");

                                    if (Inventar.Contains("Flügel der Reinheit") && !Inventar.Contains("Baal's Amulett"))
                                    {
                                        SystemAusgabe.Anweisung("Du benutzt deine Flügel, um zur Decke der Höhle zu fliegen. Du findest ein Rot leuchtendes Amulett! Fühlt sich irgendwie seltsam an... Auf der Rückseite ist etwas eingraviert: \"Baal\".");
                                        Inventar.Add("Baal's Amulett");
                                        HUD(playerName, Location, Inventar, Gold);
                                        WeiteresVorgehen(Inventar);
                                    }
                                    else
                                    {
                                        SystemAusgabe.Anweisung("Leider kommst du da nicht dran. Du solltest später wieder kommen.");
                                        WeiteresVorgehen(Inventar);
                                    }
                                }
                                else
                                {
                                    SystemAusgabe.Anweisung("Aus dem Höhleninneren ertönt ein lauter Schrei. Hört sich nicht wie der Schrei eines Menschen an, aber auch nicht wie der von einem Tier. Er klingt irgendwie Unheilvoll.");
                                }
                                
                                break;

                            case "NEIN":
                                SystemAusgabe.Anweisung("");
                                break;
                        }
                        restartSwitch = false;
                        break;

                    case "ÜBERLEGEN":
                    case "NACHDENKEN":
                    case "DENKEN":
                        SystemAusgabe.Anweisung("Die Steine an den Höhlenwänden sehen interessant aus. Du brauchst nicht einmal ein Werkzeug, um diese mit zu nehmen, wie es scheint.");
                        break;
                }  
            }
        }

        static void WeiteresVorgehen(List<string> Inventar)
        {
            bool restartSwitch = true;
            while (restartSwitch)
            {
                SystemAusgabe.Anweisung("Wie möchtest du weiter vorgehen?");
                string input = UserInput();
                switch (input)
                {
                    case "UMSEHEN":
                        if (Location == "Nautilus' Hütte")
                        {
                            SystemAusgabe.Anweisung("Du siehst dich um und siehst eine große Stadt in der ferne, sowie ein kleineres Dorf, etwas näher. Außerdem siehst du nicht weit entfernt eine große Höhle.");
                        }
                        else if (Location == "Frosthöhle")
                        {
                            SystemAusgabe.Anweisung("Du siehst dich um und siehst eine große Stadt in der ferne, sowie ein kleineres Dorf, etwas näher. Außerdem siehst du nicht weit entfernt die Hütte von Nautilus.");
                        }
                        else if (Location == "Rodermark")
                        {
                            SystemAusgabe.Anweisung("Du siehst dich um und siehst eine große Stadt, nicht weit entfernt von dir. Außerdem siehst du etwas weiter entfernt die Hütte von Nautilus. Die Höhle kannst du von hier aus auch erkennen.");
                        }
                        else if (Location == "Stadt")
                        {
                            SystemAusgabe.Anweisung("Du siehst dich um und siehst ein kleines Dorf, nicht weit entfernt von dir. Außerdem siehst in weiter ferne die Hütte von Nautilus. Die Höhle kannst du von hier aus gerado so erkennen.");
                        }

                        break;

                    case "ERKUNDEN":
                        if (Location == "Nautilus Hütte")
                        {
                            SystemAusgabe.Anweisung("Du wühlst in Nautilus' sachen rum, außer seiner alten Unterhose findest du aber nichts interessantes.");

                        }
                        else if (Location == "Frosthöhle")
                        {
                            SystemAusgabe.Anweisung("Möchtest du in die Frosthöhle gehen?");
                            input = UserInput();
                            if (input == "JA")
                            {
                                restartSwitch = false;
                                FrostHöhle(Inventar);
                            }
                            else
                            {
                                restartSwitch = false;
                                WeiteresVorgehen(Inventar);
                            }
                        }
                        else if (Location == "Rodermark")
                        {
                            SystemAusgabe.Anweisung("");
                        }
                        else if (Location == "Stadt")
                        {
                            SystemAusgabe.Anweisung("");
                        }
                        break;

                    case "HILFE":
                        SystemAusgabe.Anweisung($"Du kannst mit Hilfe von verschiedenen Eingaben weiter fortfahren. Mit \"Erkunden\", oder \"Umsehen\" erhältst du immer Hilfreiche Hinweise zu deiner aktuellen Position. Außerdem kannst du mit dem Befehl \"Reisen\" an bestimmte Orte Reisen.");
                            break;
                    case "REISEN" :
                    case "TELEPORTIEREN" :
                    case "TELEPORT" :
                    case "FLIEGEN" :
                        ReiseZiel(reiseZiel, Inventar);
                        break;
                }
            }
        }

        static void ReiseZiel(string reiseZiel, List<string> Inventar)
        {
            SystemAusgabe.Anweisung("Wohin möchtest du Reisen? Du kannst an folgende Orte Reisen: Nautilus Hütte, Frosthöhle, Rodermark, ");
            reiseZiel = UserInput();
            if (reiseZiel == "FROSTHÖHLE" || reiseZiel == "HÖHLE")
            {
                FrostHöhle(Inventar);
                Console.Clear();
            }
            else if (reiseZiel == "NAUTILUS" || reiseZiel == "NAUTILUS HÜTTE" || reiseZiel == "BAUER" || reiseZiel == "HÜTTE")
            {

            }
        }

        static string UserInput()
        {
            string input = Console.ReadLine().ToUpper();
            return input;
        }

        static void HUD(string playerName, string location, List<string> Inventar, int gold)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            int savedCursorLeft = Console.CursorLeft;
            int savedCursorTop = Console.CursorTop;

            Console.SetCursorPosition(0, 0);
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

            Console.SetCursorPosition(savedCursorLeft, savedCursorTop);

            Console.ResetColor();
            Console.CursorVisible = true;
        }

        static void UpdateHUD(int spacing, List<string> Inventar)
        {
            HUD(playerName, Location, Inventar, Gold);
            Console.Clear();
            for (int i = 0; i < spacing; i++)
            {
                Console.WriteLine("");
            }
        }

        static void EndGame()
        {
            SystemAusgabe.Anweisung($"Herzlichen Glückwunsch, {playerName}, dein Abenteuer ist zuende. Du hast {Gold} Gold gesammelt!");
            SystemAusgabe.Anweisung("Drücke Enter zum beenden.");
        }
    }
}
