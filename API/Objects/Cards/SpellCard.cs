using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class SpellCard : Card
    {
        string effect;

        public SpellCard()
        {

        }


        public override string name => "Spell";
    }
}
