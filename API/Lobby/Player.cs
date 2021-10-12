using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Player
    {
        private readonly IClientProxy client;
        private string username;
        public int[] cards = new int[5];

        public Player(IClientProxy client, string username)
        {
            this.client = client;
            this.username = username;
            for(int i = 0; i < 5; i++)
            {
                cards[i] = -1;
            }
        }
        public IClientProxy GetClient()
        {
            return client;
        }
        public string GetUsername()
        {
            return username;
        }
        public bool addToNearest(int cardId)
        {
            for(int i = 0; i < 5; i++)
            {
                if (cards[i] != -1) continue;
                else
                {
                    Console.WriteLine($"[API] Card with id {cardId} was added to {this.username}'s deck.");
                    cards[i] = cardId;
                    return true;
                }
            }
            return false;
        }
    }
}
