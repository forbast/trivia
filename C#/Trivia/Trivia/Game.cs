﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() { { 0, "Pop" }, { 1, "Science" }, { 2, "Sports" }, { 3, "Rock" } };

        QuestionStacks _questionStacks = new QuestionStacks();

        public Game()
        {
            _questionStacks.GenerateStacksQuestions();
        }

        bool isGettingOutOfPenaltyBox;

        private Player _currentPlayer;

        private void NextPlayer()
        {
            var nextPlayer = _players.IndexOf(_currentPlayer) + 1;
            if (nextPlayer == _players.Count) nextPlayer = 0;
            _currentPlayer = _players[nextPlayer];
        }

        public bool Add(string playerName)
        {
            var player = new Player(playerName);
            if (!_players.Any())
            {
                _currentPlayer = player;
            }
            _players.Add(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }


        public void Roll(int roll)
        {
            Console.WriteLine(_currentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_currentPlayer.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_currentPlayer.Name + " is getting out of the penalty box");
                    _currentPlayer.Move(roll);

                    Console.WriteLine(_currentPlayer.Name
                            + "'s new location is "
                            + _currentPlayer.Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    _questionStacks.AskQuestion(this.CurrentCategory());
                }
                else
                {
                    Console.WriteLine(_currentPlayer.Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _currentPlayer.Move(roll);

                Console.WriteLine(_currentPlayer.Name
                        + "'s new location is "
                        + _currentPlayer.Place);
                Console.WriteLine("The category is " + CurrentCategory());
                _questionStacks.AskQuestion(this.CurrentCategory());
            }

        }



        private string CurrentCategory()
        {
            return _categories[_currentPlayer.Place % 4];
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_currentPlayer.InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _currentPlayer.WinAGoldCoin();

                    winner = DidPlayerWin();
                    NextPlayer();

                    return winner;
                }

                NextPlayer();
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _currentPlayer.WinAGoldCoin();

            winner = DidPlayerWin();
            NextPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_currentPlayer.Name + " was sent to the penalty box");
            _currentPlayer.GoToPenaltyBox();

            NextPlayer();
            return true;
        }


        private bool DidPlayerWin()
        {
            return _currentPlayer.GoldCoins != 6;
        }
    }
}