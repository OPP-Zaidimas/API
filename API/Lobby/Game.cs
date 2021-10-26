using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Game
    {
        readonly List<Player> _players;
        internal readonly int Id;
        private static readonly HashSet<int> TakenIds = new();
        private Player currentTurn = null;

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

        public void ChangeTurn()
        {
            Console.WriteLine($"[API] A player in game with id {Id} has changed the turn");
            if(currentTurn == null || currentTurn == _players[1])
            {
                currentTurn = _players[0];
                return;
            }
            currentTurn = _players[1];
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
    }
}
