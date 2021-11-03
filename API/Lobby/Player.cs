using System;
using Microsoft.AspNetCore.SignalR;

namespace API.Lobby
{
    public class Player
    {
        private readonly IClientProxy _client;
        private readonly string _username;
        public int[] Cards = new int[5];
        public int[] HPs = new int[5];

        public Player(IClientProxy client, string username)
        {
            _client = client;
            _username = username;
            for (int i = 0; i < 5; i++)
            {
                Cards[i] = -1;
                HPs[i] = 0;
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

        public bool AddToNearest(int cardId, int cardHp)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] != -1) continue;

                Console.WriteLine($"[API] Card with id {cardId} was added to {_username}'s deck.");
                Cards[i] = cardId;
                HPs[i] = cardHp;
                return true;
            }

            return false;
        }
        public void AttackOnMonster(int attackerOffense, int defenderId)
        {
            if(HPs[defenderId] - attackerOffense < 0)
            {
                Cards[defenderId] = -1;
                HPs[defenderId] = 0;
            }
            else
            {
                HPs[defenderId] -= attackerOffense;
            }
        }
    }
}
