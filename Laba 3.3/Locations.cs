using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class Forest : ILocation
    {
        public IEnemy SpawnEnemy()
        {
            return new Goblin();
        }
    }

    public class Hell : ILocation
    {
        public IEnemy SpawnEnemy()
        {
            return new Devil();
        }
    }

    public class Dungeon : ILocation
    {
        public IEnemy SpawnEnemy()
        {
            switch(GameManager.GetRandomInt(1, 3))
            {
                case 1:
                    return new Skeleton();
                case 2:
                    return new AnimatedWeapon();
                default:
                    return new Doppelganger();
            }
        }
    }
}
