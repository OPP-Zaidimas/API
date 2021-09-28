using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MonsterCard : Card
    {
        int hitpoints;
        private readonly string _name;

     public MonsterCard()
     {
            _name = "Monster";
     }


     public override string name
        {
            get { return _name; }
        }
    }
}
