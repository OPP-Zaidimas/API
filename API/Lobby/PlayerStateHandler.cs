using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby
{
    public interface PlayerStateHandler
    {
        public void Handle(Player player);
    }
}
