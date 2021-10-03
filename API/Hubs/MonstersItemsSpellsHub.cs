using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Hubs
{
    public class MonstersItemsSpellsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public async Task CreateNewGame()
        {
            Console.WriteLine("received");
            //insert generate code logic somehow?
            int matchId = 450896;
            //send
            await Clients.Caller.SendAsync("ReceiveCode", matchId);
        }
    }
}
