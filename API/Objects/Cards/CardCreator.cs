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
            switch (type)
            {
                case "Spell":
                    return new SpellCard();
                case "Monster":
                    return new MonsterCard();
                case "Item":
                    return new ItemCard();
                default:
                    return new MonsterCard();

            }
            
        }


    }
}
