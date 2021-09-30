using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MonsterCard : Card
    {
        int hitpoints;

     public MonsterCard()
     {

     }


        public override string name => "Monster";
    }
}
