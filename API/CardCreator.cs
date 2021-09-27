using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class CardCreator : ICreator
    {
        public Card factoryMethod(string type, string name)
        {
            if (type.Equals("Spell"))
            {
                return new SpellCard(name);
            }
            if (type.Equals("Monster"))
            {
                return new MonsterCard(name);
            }
            if (type.Equals("Item"))
            {
                return new ItemCard(name);
            }
            else return null;
            
        }


    }
}
