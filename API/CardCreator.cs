using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class CardCreator : ICreator
    {
        public Card factoryMethod(string type= "")
        {
            if (type.Equals("Spell"))
            {
                return new SpellCard();
            }
            if (type.Equals("Monster"))
            {
                return new MonsterCard();
            }
            if (type.Equals("Item"))
            {
                return new ItemCard();
            }
            else return new MonsterCard();
            
        }


    }
}
