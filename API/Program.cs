using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Lobby;

namespace API
{
    public class Program
    {
        private static Dictionary<int, Game> games = new Dictionary<int, Game>();
        internal static Random rand = new Random();
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void RegisterGame(Game g)
        {
            games.Add(g.id, g);
        }
        public static Game GetGame(int id)
        {
            return games[id];
        }
        public static void DeleteGame(int id)
        {
            games.Remove(id);
        }
#if DEBUG
        public static List<int> getGameIds()
        {
            return games.Keys.ToList();
        }
#endif
    }
}
