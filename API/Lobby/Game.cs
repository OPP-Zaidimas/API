using System;
using System.Collections.Generic;
using API.Lobby.MatchHistoryMemento;
using API.Lobby.StateHandlers;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Game
    {
        readonly List<Player> _players;
        internal readonly int Id;
        private static readonly HashSet<int> TakenIds = new();
        private Player currentTurn = null;
        private IMemento currentState;
        public MatchHistory matchHistory;

        private static int NewID()
        {
            int returnable;

            while (TakenIds.Contains(returnable = Program.rand.Next()));

            TakenIds.Add(returnable);

            return returnable;
        }

        public Game()
        {
            _players = new List<Player>();
            Id = NewID();
            matchHistory = new MatchHistory();
            Console.WriteLine("[API] New game created with id: " + Id);
        }
        public bool AddPlayer(IClientProxy client, string username)
        {
            if(_players.Count > 1)
            {
                return false;
            }

            _players.Add(new Player(client, username));
            Console.WriteLine($"[API] {username} has joined the game with id {Id}");
            return true;
        }
        public Player GetPlayer(int id)
        {
            return _players[id];
        }

        public void StoreState()
        {
            currentState = new MatchHistoryEntry(_players[0].CurrentHP, _players[1].CurrentHP, _players[0].HPs, _players[1].HPs);
            matchHistory.AddMemento(currentState);
        }

        public MatchHistoryEntry decipherMemento(IMemento memento)
        {
            MatchHistoryEntry _entry = (MatchHistoryEntry)memento.getState();
            return _entry;
        }

        public void PrintHistory()
        {
            Console.WriteLine("Printing match history " + Id);
            for(int i = 0; i < matchHistory.GetLength(); i++)
            {
                MatchHistoryEntry entry = decipherMemento(matchHistory.GetEntry(i));
                Console.WriteLine($"TURN {i+1}:");
                Console.WriteLine($"Player {_players[0].GetUsername()}'s HP: {entry.Player1HP}");
                Console.WriteLine("Cards state:");
                for(int j = 0; j < entry.Player1CardHPs.Length; j++)
                {
                    Console.WriteLine($"Card {j+1}: {entry.Player1CardHPs[j]}");
                }
                Console.WriteLine($"Player {_players[1].GetUsername()}'s HP: {entry.Player2HP}");
                Console.WriteLine("Cards state:");
                for (int j = 0; j < entry.Player2CardHPs.Length; j++)
                {
                    Console.WriteLine($"Card {j + 1}: {entry.Player2CardHPs[j]}");
                }
            }
        }

        public void ChangeTurn()
        {
            Console.WriteLine($"[API] A player in game with id {Id} has changed the turn");
            StoreState();
            if(currentTurn == null || currentTurn == _players[1])
            {
                currentTurn = _players[0];
                _players[0].SwapHandlers(new AttackingHandler());
                _players[1].SwapHandlers(new DefendingHandler());
                return;
            }
            currentTurn = _players[1];
            _players[1].SwapHandlers(new AttackingHandler());
            _players[0].SwapHandlers(new DefendingHandler());
        }

        public bool IsPlayersTurn(Player player)
        {
            return currentTurn == player;
        }

        public Player GetPlayerByUsername(string username)
        {
            if (_players[0].GetUsername().Equals(username))
            {
                return _players[0];
            }

            if (_players[1].GetUsername().Equals(username))
            {
                return _players[1];
            }

            return null;
        }
        public Player GetDefender(string attacker)
        {
            if (_players[0].GetUsername().Equals(attacker))
            {
                return _players[1];
            }

            if (_players[1].GetUsername().Equals(attacker))
            {
                return _players[0];
            }

            return null;
        }
    }
}
