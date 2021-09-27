using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ItemCard : Card
    {
        string effect;
        int duration;

        public ItemCard(string Name, string Effect, int Duration) 
        {
            name = Name;
            effect = Effect;
            duration = Duration;
        
        }
    }
}
