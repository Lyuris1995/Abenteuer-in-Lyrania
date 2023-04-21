using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abenteuer_in_Lyrania
{
    internal class StartScreen
    {
        public static void BildschirmAusgabe()
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
            Console.WriteLine("TextAdventure Game");
            Console.ResetColor();
            Console.WriteLine("Drücke Enter zum starten.");
            Console.ReadLine();
        }
    }
}
