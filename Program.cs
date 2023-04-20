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
}
