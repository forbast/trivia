using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        private String _nom;
        
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Player(String nom)
        {
            this._nom = nom;
        }


    }
}
