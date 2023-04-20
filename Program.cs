/*
 * [Your Title]
 * by Your Name, Date
 *  
 * This work is a derivative of 
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = @"                                                                                                                                            
  ,---.  ,--.                    ,--.                                   ,--.            ,--.                                   ,--.         
 /  O  \ |  |-.  ,---. ,--,--, ,-'  '-. ,---. ,--.,--. ,---. ,--.--.    `--',--,--,     |  |   ,--. ,--.,--.--. ,--,--.,--,--, `--' ,--,--. 
|  .-.  || .-. '| .-. :|      \'-.  .-'| .-. :|  ||  || .-. :|  .--'    ,--.|      \    |  |    \  '  / |  .--'' ,-.  ||      \,--.' ,-.  | 
|  | |  || `-' |\   --.|  ||  |  |  |  \   --.'  ''  '\   --.|  |       |  ||  ||  |    |  '--.  \   '  |  |   \ '-'  ||  ||  ||  |\ '-'  | 
`--' `--' `---'  `----'`--''--'  `--'   `----' `----'  `----'`--'       `--'`--''--'    `-----'.-'  /   `--'    `--`--'`--''--'`--' `--`--' 
                                                                                               `---'                                        ";

            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine("Drücke Enter zum starten.");
            Console.ReadLine();
            Game.StartGame();
            Console.ReadLine();
        }
    }

    public static class Game
    {
        static string playerName = "";

        public static void StartGame()
        {
            string Location = "Startzone";
            int Turn = 0;
            int Gold = 0;

            Console.Title = "Abenteuer in Lyrania";

            while (Turn < 20)
            {
                Turn++; Gold++;
                HUD(playerName, Location, Turn, Gold);
            }
            
            Console.WriteLine("Willkommen, Abenteurer!");
            Console.WriteLine("Du wirst gleich nach Lyrania reisen, mach dich bereit.");
            PlayerClass();
            Console.WriteLine("Plötzlich hörst du eine rauschende Stimme ertönen. Es ist Dunkel und du siehst nur den Umriss dieser Person. Es sieht so aus, als ob sie Flügel habe.");
            SystemDialog("\"Du wirst nun nach Lyrania beschworen. Dein Abenteuer beginnt!\"");
            Console.WriteLine("Dir wird schwarz vor Augen... Als du aufwachst, findest du dich auf einer riesigen großen Wiese unter einem Baum wieder.");
            Console.Clear();
            Console.WriteLine("Du siehst einen jungen Mann, welcher gerade dabei ist, Samen zu säen. Er sieht dich ebenfalls und kommt auf dich zu.");
            StrangerDialog("\"Servus! Hab' dich gar nich' geseh'n. Wo kommst'n du her? Wenn du hier bleiben willst schnapp dir ein paar Samen, oder verzieh dich!\"", "green");

        }

        static void PlayerClass()
        {
            Console.WriteLine("Bitte gib deinen Namen ein: ");
            playerName = Console.ReadLine();
            Console.WriteLine($"Deine Name lautet nun: {playerName}");

            
        }

        static void SystemDialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void StrangerDialog(string message, string color)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }


        public static void HUD(string player, string location, int turn, int gold)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    " + player);
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

    class Item
    {

    }
}
