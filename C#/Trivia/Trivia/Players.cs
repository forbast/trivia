using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Players
    {
        private List<Player> _players = new List<Player>();

        public List<Player> Players1
        {
            get { return _players; }
            set { _players = value; }
        }

        public Players()
        {
        }

        public bool Add(string playerName)
        {
            var player = new Player(playerName);
            if (!_players.Any())
            {
                //_currentPlayer = player;
            }
            _players.Add(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

    }
}
