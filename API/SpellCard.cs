using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class SpellCard : Card
    {
        string effect;
        private readonly string _name;

        public SpellCard()
        {
            _name = "Spell";
        }


        public override string name
        {
            get { return _name; }
        }
    }
}
