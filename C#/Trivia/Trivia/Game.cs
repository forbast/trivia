using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {   
        private readonly Players _players;

        private readonly Questions _questions;
        
        bool isGettingOutOfPenaltyBox;
        private IDisplay _display = new ConsoleDisplay();


        public Game(Players players, Questions questions)
        {
            _players = players;
            _questions = questions;
        }

        public void Roll(int roll)
        {
            _display.Display(_players.Current.Name + " is the current player");
            _display.Display("They have rolled a " + roll);

            if (_players.Current.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    _display.Display(_players.Current.Name + " is getting out of the penalty box");
                    _players.Current.Move(roll);

                    _display.Display(_players.Current.Name
                            + "'s new location is "
                            + _players.Current.Place);
                    _questions.AskQuestion(_players.Current.Place);
                }
                else
                {
                    _display.Display(_players.Current.Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.Current.Move(roll);

                _display.Display(_players.Current.Name
                        + "'s new location is "
                        + _players.Current.Place);
                _questions.AskQuestion(_players.Current.Place);
            }

        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.Current.InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    _display.Display("Answer was correct!!!!");
                    _players.Current.WinAGoldCoin();

                    winner = _players.Current.IsWinner();
                    _players.NextPlayer();

                    return winner;
                }

                _players.NextPlayer();
                return false;
            }

            _display.Display("Answer was corrent!!!!");
            _players.Current.WinAGoldCoin();

            winner = _players.Current.IsWinner();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            _display.Display("Question was incorrectly answered");
            _display.Display(_players.Current.Name + " was sent to the penalty box");
            _players.Current.GoToPenaltyBox();

            _players.NextPlayer();
            return false;
        }
    }

}
