using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Lobby;

namespace API.Hubs
{
    public class MonstersItemsSpellsHub : Hub
    {
        //Dict gameid -> game
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public async Task CreateNewGame(string username)
        {
            Game game = new Game();
            game.AddPlayer(Clients.Caller, username);
            Program.RegisterGame(game);
#if DEBUG
            foreach(int id in Program.getGameIds())
            {
                Console.WriteLine("[API] Game id: " + id);
            }
#endif
            //send
            await Clients.Caller.SendAsync("ReceiveCode", game.id);
        }
        public async Task JoinGame(int matchId, string username)
        {
            Game game;
            try
            {
                game = Program.GetGame(matchId);
            }
            catch(Exception e)
            {
                await Clients.Caller.SendAsync("ReceiveFailure",
                    "Game with such id does not exist");
                return;
            }
            if (game.AddPlayer(Clients.Caller, username))
            {
                //start game for each client in game

                //retrieve data of game players
                Player player1 = game.GetPlayer(0);
                Player player2 = game.GetPlayer(1);
                /*
                 * @arg1 - opponent name
                 */
                await player1.GetClient().SendAsync("StartGame", player2.GetUsername());
                await player2.GetClient().SendAsync("StartGame", player1.GetUsername());
            }
            else
            {
                //failure to join due to too many players
                await Clients.Caller.SendAsync("ReceiveFailure", 
                    "Game is already full and in progress");
            }
        }
    }
}
