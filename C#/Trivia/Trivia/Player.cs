using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        public string Nom { get; set; }
        public int Place { get; set; }
        public int Purse { get; set; }
        public bool InPenaltyBox { get; set; }

        public Player(string nom)
        {
            Nom = nom;
            Place = 0;
            Purse = 0;
            InPenaltyBox = false;
        }
    }
}
