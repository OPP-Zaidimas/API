using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby
{
    public class GamesManager
    {
        private Dictionary<int, Game> games;

        public static GamesManager Instance {
            get 
            {
                if(_instance==null)
                {
                    _instance = new GamesManager();
                }
                return _instance;
            } 
        }

        private static GamesManager _instance;

        private GamesManager()
        {
            
            games = new Dictionary<int, Game>();
        }

        public void RegisterGame(Game g)
        {
            games.Add(g.id, g);
        }
        public Game GetGame(int id)
        {
            return games[id];
        }
        public void DeleteGame(int id)
        {
            games.Remove(id);
        }
#if DEBUG
        public List<int> getGameIds()
        {
            return games.Keys.ToList();
        }
#endif
    }
}
