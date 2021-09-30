using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Objects.Heroes
{
    public class HeroCreator : ICreator
    {
        public Hero factoryMethod(string type = "")
        {
            switch (type)
            {
                case "Tank":
                    return new TankHero();
                case "Berserker":
                    return new BerserkerHero();
                case "Ranger":
                    return new RangerHero();
                default:
                    return new TankHero();

            }

        }


    }
}
