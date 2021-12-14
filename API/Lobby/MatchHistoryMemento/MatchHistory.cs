using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby.MatchHistoryMemento
{
    public class MatchHistory
    {
        public List<IMemento> mementos;

        public MatchHistory()
        {
            mementos = new List<IMemento>();
        }
        public IMemento GetEntry(int index)
        {
            return mementos[index];
        }
        public void AddMemento(IMemento memento)
        {
            mementos.Add(memento);
        }
        public int GetLength()
        {
            return mementos.Count();
        }
    }
}
