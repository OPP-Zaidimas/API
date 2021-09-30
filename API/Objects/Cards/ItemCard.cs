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

        public ItemCard()
        {
        }


        public override string name => "Item";

    }
}
