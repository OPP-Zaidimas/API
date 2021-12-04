using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Lobby
{
    public enum States : uint
    {
        WAITING = 0,
        ATTACKING = 1,
        DEFENDING = 2
    }
}
