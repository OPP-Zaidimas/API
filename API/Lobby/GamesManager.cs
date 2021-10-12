using System.Collections.Generic;
using System.Linq;

namespace API.Lobby
{
    public class GamesManager
    {
        private readonly Dictionary<int, Game> _games;

        public static GamesManager Instance
        {
            get { return _instance ??= new GamesManager(); }
        }

        private static GamesManager _instance;

        private GamesManager()
        {
            _games = new Dictionary<int, Game>();
        }

        public void RegisterGame(Game g)
        {
            _games.Add(g.Id, g);
        }

        public Game GetGame(int id)
        {
            return _games[id];
        }

        public void DeleteGame(int id)
        {
            _games.Remove(id);
        }
#if DEBUG
        public List<int> GetGameIds()
        {
            return _games.Keys.ToList();
        }
#endif
    }
}
