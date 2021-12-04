using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby
{
    public class WaitingHandler : PlayerStateHandler
    {
        public void Handle(Player player)
        {
            player.State = States.WAITING;
        }
    }
}
