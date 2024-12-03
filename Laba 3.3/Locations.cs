using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    internal class Forest : ILocation
    {
        public string SpawnEnemy()
        {
            return "Goblin";
        }
    }

    internal class Hell : ILocation
    {
        public string SpawnEnemy()
        {
            return "Devil";
        }
    }

    internal class Dungeon : ILocation
    {
        public string SpawnEnemy()
        {
            return "Skeleton";
        }
    }
}
