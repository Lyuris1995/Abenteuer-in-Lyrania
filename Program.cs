/*
 * [Abenteuer in Lyrania]
 * by Julian Schmidt, 20.04.2023
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
            //Console.SetWindowSize(200, 100);
            StartScreen.BildschirmAusgabe();
            Game.StartGame();
            Console.ReadLine();
        }
    }
}
