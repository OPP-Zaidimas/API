using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Game
    {
        List<Player> players;
        int id;

        public Game(int id)
        {
            players = new List<Player>();
            this.id = id;
            Console.WriteLine("[API] New game created with id: " + id);
        }
        public bool AddPlayer(IClientProxy client, string username)
        {
            if(players.Count > 1)
            {
                return false;
            }
            else
            {
                players.Add(new Player(client, username));
                Console.WriteLine(String.Format("[API] {0} has joined the game with id {1}", username, id));
                return true;
            }
        }
        public Player GetPlayer(int id)
        {
            return players[id];
        }
    }
}
