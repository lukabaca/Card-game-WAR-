﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    public class Deck
    {

        //K - kier, P - pik, T - trefl, 
        private static List<String> gameDeck = new List<String>()

        {"2_PIK", "3__PIK", "4__PIK", "5__PIK", "6__PIK", "7__PIK", "8__PIK", "9__PIK", "10__PIK", "J__PIK", "D__PIK", "K__PIK", "A__PIK",
         "2_KIER", "3_KIER", "4_KIER", "5_KIER", "6_KIER", "7_KIER", "8_KIER", "9_KIER", "10_KIER", "J_KIER", "D_KIER", "K_KIER", "A_KIER"

        };

        private List<String> serverDeck;

        private List<String> clientDeck;

        public void shuffleGameDeck()
        {
            var rand = new Random();

            gameDeck = gameDeck.OrderBy(x => rand.Next()).ToList();

            //printDeck();

        }

        public void initPlayersDecks()
        {
            
        }

        public void printDeck()
        {
            foreach(String card in gameDeck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("------------------------------");
        }

    }
}
