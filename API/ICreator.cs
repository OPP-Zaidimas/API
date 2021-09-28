using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    interface ICreator
    {
        public Card factoryMethod(string type)
        {
            return null;
        }
    }
}
