using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Players
    {
        private IDisplay _display = new ConsoleDisplay();

        private readonly List<Player> _players = new List<Player>();

        public Player Current { get; private set; }

        public void NextPlayer()
        {
            var nextPlayer = _players.IndexOf(Current) + 1;
            if (nextPlayer == _players.Count) nextPlayer = 0;
            Current = _players[nextPlayer];
        }

        public bool Add(string playerName)
        {
            var player = new Player(playerName);
            if (!_players.Any())
            {
                Current = player;
            }
            _players.Add(player);

            _display.Display(playerName + " was added");
            _display.Display("They are player number " + _players.Count);
            return true;
        }
    }
}
