using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby.MatchHistoryMemento
{

    public class MatchHistoryEntry : IMemento
    {
        public MatchHistoryEntry()
        {
        }

        public MatchHistoryEntry(int player1HP, int player2HP, int[] player1CardHPs, int[] player2CardHPs)
        {
            Player1HP = player1HP;
            Player2HP = player2HP;
            Player1CardHPs = player1CardHPs;
            Player2CardHPs = player2CardHPs;
        }

        public int Player1HP { get; set; }
        public int Player2HP { get; set; }
        public int[] Player1CardHPs { get; set; }
        public int[] Player2CardHPs { get; set; }

        public IMemento getState()
        {
            return this;
        }

        public void setState(IMemento entry)
        {
            MatchHistoryEntry _entry = (MatchHistoryEntry)entry;
            this.Player1CardHPs = entry.Player1CardHPs;
            this.Player2CardHPs = entry.Player2CardHPs;
            this.Player1HP = entry.Player1HP;
            this.Player2HP = entry.Player2HP;
        }
    }
}
