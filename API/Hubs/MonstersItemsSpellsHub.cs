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
        Dictionary<int, Game> games = new Dictionary<int, Game>();
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }

        public async Task CreateNewGame(string username)
        {
            int matchId = new Random().Next();
            while(games.ContainsKey(matchId))
            {
                matchId = new Random().Next();
            }
            Game game = new Game(matchId);
            game.AddPlayer(Clients.Caller, username);
            games.Add(matchId, game);
            foreach(int id in games.Keys)
            {
                Console.WriteLine("[API] Game id: " + id);
            }
            //send
            await Clients.Caller.SendAsync("ReceiveCode", matchId);
        }
        public async Task JoinGame(int matchId, string username)
        {
            if(!games.ContainsKey(matchId))
            {
                //game doesn't exist
                await Clients.Caller.SendAsync("ReceiveFailure", 
                    "Game with this Match ID does not exist.");
                return;
            }
            Game game;
            if (!games.TryGetValue(matchId, out game))
            {
                //failure to join game: internal error
                await Clients.Caller.SendAsync("ReceiveFailure", 
                    "Server was not able to retrieve an active session");
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
