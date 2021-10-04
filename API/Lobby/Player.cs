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

        public Player(IClientProxy client, string username)
        {
            this.client = client;
            this.username = username;
        }
        public IClientProxy GetClient()
        {
            return client;
        }
        public string GetUsername()
        {
            return username;
        }
    }
}
