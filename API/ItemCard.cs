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
        private readonly string _name;

        public ItemCard()
        {
            _name = "Item";
        }


        public override string name
        {
            get { return _name; }
        }
    }
}
}
