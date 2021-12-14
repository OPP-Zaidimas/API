using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby.MatchHistoryMemento
{
    public interface IMemento
    {
        public int Player1HP { get; set; }
        public int Player2HP { get; set; }
        public int[] Player1CardHPs { get; set; }
        public int[] Player2CardHPs { get; set; }

        public void setState(IMemento entry);
        public IMemento getState();
    }
}
