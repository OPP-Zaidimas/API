using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class SpellCard : Card
    {
        string effect;




     public SpellCard(string Name, string Effect)
     {
         name = Name;
         effect = Effect;
     }
    }
}
