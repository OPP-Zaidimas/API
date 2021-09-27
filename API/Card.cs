using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public abstract class Card
    {
        string name;
        public Card(string Name)
        {
            name = Name;
        }
    }
}
