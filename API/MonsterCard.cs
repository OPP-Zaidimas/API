using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MonsterCard : Card
    {
        int hitpoints;



     public MonsterCard(string Name, int Hitpoints)
     {
        name = Name;
        hitpoints = Hitpoints;
     }
    }
}
