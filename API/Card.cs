using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public abstract class Card
    {
        public string name;
        public string getName()
        {
            return name;
        }
    }
}
