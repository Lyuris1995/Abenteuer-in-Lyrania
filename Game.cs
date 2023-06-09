﻿using System;
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
        static public bool nautilusHilfe = false;
        static public bool geldbörse = true;
        static public bool bierGekauft = false;
        static public int Gold = 0;

        public static void StartGame()
        {
            string Location = "Startzone";
            int Gold = 0;
            List<string> Inventar = new List<string>();

            Console.Title = "Abenteuer in Lyrania";

            UpdateHUD(3, Inventar);
            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            HUD(playerName, Location, Inventar, Gold);
            PlayerCharacter(Inventar);
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemAusgabe.Anweisung("Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.WriteLine("Du siehst einen älteren Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            NautilusDialog("Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen,\n ansonsten geh runter von mei'm Feld!", Inventar);
            if (nautilusHilfe == false)
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

        static void NautilusDialog(string message, List<string> Inventar)
        {
            CharakterNautilus.NautilusText(message);

            while (true)
            {
                SystemAusgabe.Anweisung($"Du musst nun deine erste Entscheidung treffen, {playerName}. Willst du dem Bauern helfen? ");
                SystemAusgabe.Anweisung("Tippe 1) für Ja und 2) für Nein");
                SystemAusgabe.Anweisung("Hinweis: Solche Entscheidungen müssen immer wieder während deines Abenteuers getroffen werden. Bestätige deine Entscheidung immer mit der Enter-Taste, damit dein Abenteuer weiter gehen kann.");
                int inputNautiHilfe = UserInput();
                UpdateHUD(3, Inventar);

                if (inputNautiHilfe == 1)
                {
                    Gold += 1;
                    nautilusHilfe = true;
                    UpdateHUD(3, Inventar);
                    SystemAusgabe.Anweisung("Du hast dich dafür entschieden dem Bauern zu helfen. Du erhältst eine Goldmünze!");
                    break;
                }
                else if (inputNautiHilfe == 2)
                {
                    SystemAusgabe.Anweisung("Du hast dich dagegen entschieden dem Bauern zu helfen.");
                    nautilusHilfe = false;
                    HUD(playerName, Location, Inventar, Gold);
                    break;
                }
            }

            if (nautilusHilfe == true)
            {
                CharakterNautilus.NautilusText($"Komm, wir gehen erst mal in meine Hütte. Mein Name ist übrigens {nautilusName}");
                Location = "Nautilus' Hütte";
                HUD(playerName, Location, Inventar, Gold);
                CharakterNautilus.NautilusText("Vielen Dank, dass du mir geholfen hast. Is' nich' selbstverständlich, weißte? Ich war ziemlich gemein zu dir,\ndas tut mir Leid. Würdest du mir verraten, wo du her kommst?");
                SystemAusgabe.Anweisung("Möchtest du dem Bauern verraten, wo du her kommst?");
                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                int inputNautiHerkunft = UserInput();
                if (inputNautiHerkunft == 1)
                {
                    SystemAusgabe.Anweisung("Du erzählst dem Bauern alles, deinen Namen, wo du ursprünglich herkommst und dass du keine Ahnung hast,\n wie du hier her gekommen bist, außer, dass da ein Wesen mit Flügeln war.");
                    CharakterNautilus.NautilusText($"m-m-m-Moment, langsam jetz'! Du heißt {playerName}, kommst aus einem Land namens \"Deutschland\" und wurdest von einem Wes'n mit Flügeln hergebracht?\nDas klingt alles ziemlich aufregend und ich hab' keine Ahnung, was das alles bedeutet. Aber du hast mir geholfen und mir vertraut,\ndafür Schulde ich dir was. Wenn du möchtest, darfst du gerne hier schlafen.\nFreut mich, dich kennen zu lernen!");
                }
                else if (inputNautiHerkunft == 2)
                {
                    SystemAusgabe.Anweisung("Du sagst lediglich deinen Namen und dass du nicht genau weißt, wo du bist und wie du hier her gekommen bist.");
                    CharakterNautilus.NautilusText($"Oh, {playerName} heißt du also? Komischer Name, den hab' ich hier noch nie gehört. Wie dem auch sei,\ndu hast mir sehr geholfen, dafür Schuld' ich dir was.\nDu hast zwar schon 'n Gold von mir bekommen, aber das reicht nich', um dich zu vergüt'n.\nWenn du möchtest, darfst du hier schlaf'n und dich ausruh'n, was zu Ess'n kann ich dir auch anbiet'n!");
                }
            }
            else if (nautilusHilfe == false)
            {
                CharakterNautilus.NautilusText("Dann mach dass du verschwindest! Ich hab' keine Zeit für so'n faulen Typ wie dich!");
                SystemAusgabe.Anweisung("Der Bauer verscheucht dich mit seiner Mistgabel. Du rennst so schnell wie du kannst, bis du in einer Höhle ankommst.");      
            }
        }

        static void FrostHöhle(List<string> Inventar)
        {
            Location = "Frosthöhle";
            UpdateHUD(3, Inventar);
            SystemAusgabe.Anweisung("Du befindest dich nun vor einer Höhle mit Blauen Steinen, die überall an den Wänden hängen. Was möchtest du tun?");
            SystemAusgabe.Anweisung("1) Erkunden / 2) Nachdenken");
            bool restartSwitch = true;

            while(restartSwitch)
            {
                int inputFrosthöhleErkundung = UserInput();
                switch (inputFrosthöhleErkundung) 
                {
                    case 1:

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
                        SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                        inputFrosthöhleErkundung = UserInput();
                        switch (inputFrosthöhleErkundung)
                        {
                            case 1:

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

                            case 2:
                                SystemAusgabe.Anweisung("");
                                break;
                        }
                        restartSwitch = false;
                        break;

                    case 2:
                        SystemAusgabe.Anweisung("Die Steine an den Höhlenwänden sehen interessant aus. Du brauchst nicht einmal ein Werkzeug, um diese mit zu nehmen, wie es scheint.");
                        break;
                }  
            }
        }

        static void NautilusHütte(List<string> Inventar)
        {
            Location = "Nautilus' Hütte";
            UpdateHUD(3, Inventar);

            if (nautilusHilfe == true && Inventar.Contains("Baal's Amulett"))
            {
                CharakterNautilus.NautilusText("WOW, da in deiner Tasche leuchtet was, ist das etwa...?");
                SystemAusgabe.Anweisung("Möchtest du Nautilus Baal's Amulett zeigen?");
                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                int inputNautilusHütte = UserInput();
                if (inputNautilusHütte == 1)
                {
                    CharakterNautilus.NautilusText($"Du hast Baal's Amulett gefunden?! Das ist nicht gut... Du musst dieses Amulett gut beschützen, hörst du {playerName}? Baal ist ein Dämon, welcher unser Land vor Jahrhunderten heimgesucht hat. Er konnte nur durch sehr viele verluste in der großen Höhle versiegelt werden. Seitdem traut sich niemand mehr auch nur in die Nähe dieser Höhle.");
                    SystemAusgabe.Anweisung("Möchtest du Nautilus verraten, wo du das Amulett gefunden hast?");
                    inputNautilusHütte = UserInput();
                    if (inputNautilusHütte == 1)
                    {
                        CharakterNautilus.NautilusText("Was?! Du hast das Amulett an der DECKE in der Frosthöhle gefunden? Wie zum Teufel gerät ein Amulett an die Decke einer Eisigen Höhle?! Hör mal Junge, ich glaube hier ist etwas ganz großes im Gange. Du solltest in die Stadt gehen und einem der Paladine dies alles erzählen. Vielleicht haben die eine Ahnung, was hier vorgeht.");

                    }
                }
                else
                {
                    CharakterNautilus.NautilusText("Hmpf, dann eben nicht. Ich dachte, wir können einander vertrauen.");
                    SystemAusgabe.Anweisung("Nautilus sieht ziemlich enttäuscht aus.");
                }
            }
            else if (nautilusHilfe == true)
            {
                CharakterNautilus.NautilusText("Ah, da biste ja wieder! Ich muss dir was erzählen. Ich habe gehört, dass es in dem Dorf da unten, Rodermark heißt es, eine Kapelle gibt, in der wohl ein besonderes Artefakt versteckt wird. Vielleicht hilft dir das Artefakt ja herauszufinden, wo du her kommst.");
                WeiteresVorgehen(Inventar);
            }
            else if (nautilusHilfe == false && Inventar.Contains("Baal's Amulett"))
            {
                CharakterNautilus.NautilusText("Du schon wieder? Moment, ich spüre eine Unheilvolle Energie bei dir... kann es sein...?");
                SystemAusgabe.Anweisung("Möchtest du dem alten Mann Baal's Amulett zeigen?");
                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                int inputNautilusHütte = UserInput();
                if (inputNautilusHütte == 1)
                {

                }
                else
                {

                }
            }
            else if (nautilusHilfe == false)
            {
                CharakterNautilus.NautilusText("Du schon wieder? Hast's dir anders überlegt und willst mir doch zur Hand geh'n?");
                SystemAusgabe.Anweisung("Möchtest du dem alten Mann beim säen der Samen helfen?");
                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                int inputNautilusHütte = UserInput();
                if (inputNautilusHütte == 1)
                {
                    Gold += 1;
                    UpdateHUD(3, Inventar);
                    nautilusHilfe = true;
                    CharakterNautilus.NautilusText($"Na super, dann los, nimm dir ein paar Samen und fang an! Mein Name ist übrigens {nautilusName}");
                    SystemAusgabe.Anweisung("Du hilfst Nautilus beim säen. Er gibt dir 1 Gold als Dank.");
                }
                else if (inputNautilusHütte == 2)
                {
                    CharakterNautilus.NautilusText("NA DANN HAU ENDLICH AB!!!");
                    SystemAusgabe.Anweisung("... Der alte Mann verscheucht dich mit seiner Mistgabel. Du landest wieder vor der Frosthöhle.");
                    FrostHöhle(Inventar);
                }
            }

        }

        static void Rodermark(List<string> Inventar)
        {
            Location = "Rodermark";
            UpdateHUD(3, Inventar);
            SystemAusgabe.Anweisung("Du bist jetzt in Rodermark. Was möchtest du tun?");
            SystemAusgabe.Anweisung("1) Umsehen / 2) Ins Gasthaus gehen");
            int inputRodermark = UserInput();
            if (inputRodermark == 1)
            {
                if (geldbörse == true)
                {
                    Gold += 5;
                    geldbörse = false;
                    UpdateHUD(3, Inventar);
                    SystemAusgabe.Anweisung("Heute ist dein Glückstag, da lag eine geldbörse mit 5 Goldmünzen auf dem Boden!");
                }
                SystemAusgabe.Anweisung("Ein nettes kleines Dorf. Du siehst eine Kapelle und ein Gasthaus, ansonsten nichts besonderes. (Drücke Enter zum fortfahren.)");
                Console.ReadLine();
                Rodermark(Inventar);
            }
            else if (inputRodermark == 2)
            {
                SystemAusgabe.Anweisung("Du betrittst das Gasthaus. Außer ein paar älteren Herrschaften ist hier nicht viel los. An der Theke steht eine Junge Frau, sie scheint die Schankwirtin zu sein. Möchtest du mit ihr reden?");
                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                inputRodermark = UserInput();
                if (inputRodermark == 1)
                {
                    Schankwirtin.WirtinText("Oh, Hallöchen, du scheinst neu hier zu sein. Kann ich dir etwas anbieten?");
                    SystemAusgabe.Anweisung("Was möchtest du tun?");
                    SystemAusgabe.Anweisung("1) Bier Bestellen / 2) Reden");
                    bool resetSwitch = true;
                    while (resetSwitch)
                    {
                        inputRodermark = UserInput();
                        switch (inputRodermark)
                        {
                            case 1:
                                Schankwirtin.WirtinText("Sehr gerne, ein Bier kostet 1 Gold, soll ich dir ein Bier bringen?");
                                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                                inputRodermark = UserInput();
                                if (inputRodermark == 1 && Gold >= 1)
                                {
                                    Gold -= 1;
                                    resetSwitch = false;
                                    bierGekauft = true;
                                    UpdateHUD(3, Inventar);
                                    Schankwirtin.WirtinText("Hier bitteschön, ich hoffe es Mundet! Kann ich sonst noch etwas für dich tun?");
                                }
                                else if (inputRodermark == 2 || Gold < 1)
                                {
                                    resetSwitch = false;
                                    Schankwirtin.WirtinText("Oh, wie es scheint hast du nicht genügend Gold bei dir. Vielleicht solltest du dich mal in der gegend umsehen, ob du jemandem für etwas Gold helfen kannst?");
                                }
                                break;

                            case 2:
                                Schankwirtin.WirtinText("Du kommst nur zum reden hier her?");
                                SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                                input = UserInput();
                                if (input == 1 && bierGekauft == true)
                                {
                                    resetSwitch = false;
                                    Schankwirtin.WirtinText("Ich habe gehört, dass es in der Kapelle ein besonderes Artefakt gibt. Es sollen Schwingen oder ähnliches sein, was es wohl damit auf sich hat?");
                                }
                                else if (input == 1 && bierGekauft == false)
                                {
                                    Schankwirtin.WirtinText("Leider bieten wir \"Reden\" nicht in unserem Sortiment an. Wenn du ein Bier kaufen möchtest, könnte das vielleicht meine Lippen lockern.");
                                }
                                else if (input == 2)
                                {
                                    Schankwirtin.WirtinText("Okay, dann eben nicht. :(");
                                }
                                break;
                        }
                    }
                }
                else if (inputRodermark == 2)
                {
                    SystemAusgabe.Anweisung("Du verlässt das Gasthaus wieder.");
                }
            }
            else if (input == 3)
            {
                SystemAusgabe.Anweisung("Du stehst vor der Kapelle. Hier ist reges treiben, du sieht ein paar Priester miteinander reden. Was möchtest du tun?");
                SystemAusgabe.Anweisung("1) Kapelle betreten / 2) Mit den Priestern reden / 3) Umsehen / 4) Weg gehen");
                input = UserInput();
                bool resetSwitch = true;
                while (resetSwitch)
                {
                    switch (input)
                    {
                        case 1:
                            resetSwitch = false;
                            SystemAusgabe.Anweisung("Du betrittst die Kapelle. In der Kapelle steht ein Alter Mann in einer Opulenten Robe. Möchtest du mit ihm sprechen?");
                            SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                            input = UserInput();
                            if (input == 1)
                            {
                                Priester.Dialog("Oh, Willkommen in unserer Kapelle, Reisender. Kann ich dir irgendwie behilflich sein?");
                                SystemAusgabe.Anweisung("1) Nach dem Artefakt fragen / 2) Weg gehen");
                                input = UserInput();
                                if (input == 1)
                                {
                                    Priester.Dialog("Artefakt? Ich weiß nicht, was du meinst. Ich habe jetzt auch keine Zeit, um mit dir zu reden. Wenn du mich bitte entschuldigen würdest.");
                                    SystemAusgabe.Anweisung("Der Priester verlässt die Kapelle. Du bist nun ganz alleine hier, hinter dem Altar kannst du eine Tür erkennen. Möchtest du dich der Tür nähern?");
                                    SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                                    input = UserInput();
                                    if (input == 1 && Inventar.Contains("Kapellenschlüssel"))
                                    {
                                        Inventar.Add("Flügel der Reinheit");
                                        UpdateHUD(3, Inventar);
                                        SystemAusgabe.Anweisung("Du öffnest die Tür mit deinem Kapellenschlüssel. Dahinter befindet sich ein Raum, in welchem weiß leuchtende Flügel liegen. Du steckst die Flügel ein, das muss das Artefakt sein, von dem dir erzählt wurde.");

                                    }
                                }
                            }
                            break;

                        case 2:
                            break;

                        case 3:
                            resetSwitch = false;
                            Inventar.Add("Kapellenschlüssel");
                            UpdateHUD(3, Inventar);
                            SystemAusgabe.Anweisung("Das Kapellengebäude glänzt irgendwie ganz schön... Oh, da liegt ein Schlüssel? Du steckst ihn Sicherheitshalber ein, bevor ihn jemand anders nimt.");
                            break;

                        case 4:
                            Rodermark(Inventar);
                            resetSwitch = false;
                            break;
                    }
                }
            }
        }

        static void WeiteresVorgehen(List<string> Inventar)
        {
            bool restartSwitch = true;
            while (restartSwitch)
            {
                SystemAusgabe.Anweisung("Wie möchtest du weiter vorgehen?");
                SystemAusgabe.Anweisung("1) Umsehen / 2) Gegend Erkunden 3) Weiter Reisen");
                int inputWeiteresVorgehen = UserInput();
                switch (inputWeiteresVorgehen)
                {
                    case 1:
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

                    case 2:
                        if (Location == "Nautilus' Hütte")
                        {
                            SystemAusgabe.Anweisung("Du wühlst in Nautilus' sachen rum, außer seiner alten Unterhose findest du aber nichts interessantes.");

                        }
                        else if (Location == "Frosthöhle")
                        {
                            SystemAusgabe.Anweisung("Möchtest du in die Frosthöhle gehen?");
                            SystemAusgabe.Anweisung("1) Ja / 2) Nein");
                            inputWeiteresVorgehen = UserInput();
                            if (inputWeiteresVorgehen == 1)
                            {
                                restartSwitch = false;
                                FrostHöhle(Inventar);
                            }
                            else if (inputWeiteresVorgehen == 2)
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


                    case 3:
                        ReiseZiel(Inventar);
                        break;
                }
            }
        }

        static void ReiseZiel(List<string> Inventar)
        {
            int input = UserInput();
            SystemAusgabe.Anweisung("Wohin möchtest du Reisen? Du kannst an folgende Orte Reisen: 1) Frosthöhle 2) Nautilus' Hütte 3) Rodermark 4) Kernstadt");
            if (UserInput() == 1)
            {
                Console.Clear();
                FrostHöhle(Inventar);
            }
            else if (UserInput() == 2)
            {
                Console.Clear();
                NautilusHütte(Inventar);
            }
            else if (UserInput() == 3)
            {
                Console.Clear();
                Rodermark(Inventar);
            }
            else if (inputReiseZiel == 4)
            {
                Console.Clear();

            }
        }

        static int UserInput()
        {
            string inputUser = Console.ReadLine();
            int value;
            if (int.TryParse(inputUser, out value))
            {
                return value;
            }
            else
            {
                SystemAusgabe.Anweisung("Ungültige Eingabe. Bitte gib eine Zahl ein.");
                return UserInput();
            }
            
        }

        static void HUD(string playerName, string location, List<string> Inventar, int gold)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            int savedCursorLeft = Console.CursorLeft;
            int savedCursorTop = Console.CursorTop;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("==================================================================================================================");
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
            Console.WriteLine("==================================================================================================================\n\n\n\n");

            Console.SetCursorPosition(savedCursorLeft, savedCursorTop);

            Console.ResetColor();
            Console.CursorVisible = true;
        }

        static void UpdateHUD(int spacing, List<string> Inventar)
        {
            Console.Clear();
            HUD(playerName, Location, Inventar, Gold);
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
