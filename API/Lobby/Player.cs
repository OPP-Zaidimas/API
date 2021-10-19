using System;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Player
    {
        private readonly IClientProxy _client;
        private readonly string _username;
        public readonly int[] Cards = new int[5];

        public Player(IClientProxy client, string username)
        {
            _client = client;
            _username = username;
            for (int i = 0; i < 5; i++)
            {
                Cards[i] = -1;
            }
        }

        public IClientProxy GetClient()
        {
            return _client;
        }

        public string GetUsername()
        {
            return _username;
        }

        public bool AddToNearest(int cardId)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] != -1) continue;

                Console.WriteLine($"[API] Card with id {cardId} was added to {_username}'s deck.");
                Cards[i] = cardId;
                return true;
            }

            return false;
        }
    }
}
