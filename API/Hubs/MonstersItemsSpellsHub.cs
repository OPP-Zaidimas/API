using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Hubs
{
    public class MonstersItemsSpellsHub : Hub
    {
        public async Task CreateNewGame()
        {
            Console.WriteLine("got it");
            //insert generate code logic somehow?
            int GenCode = 0;
            //send
            await Clients.Caller.SendAsync("ReceiveCode", GenCode);
        }
    }
}
