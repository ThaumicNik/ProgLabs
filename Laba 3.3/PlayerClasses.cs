using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    internal class Warrior : IPlayerClass
    {
        public string GetWeapon()
        {
            return "Longsword";
        }

        public string GetArmor()
        {
            return "Plate armor";
        }

        public ILocation GetStartLocation()
        {
            return new Dungeon();
        }
    }

    internal class Rogue : IPlayerClass
    {
        public string GetWeapon()
        {
            return "Bow";
        }

        public string GetArmor()
        {
            return "Leather armor";
        }

        public ILocation GetStartLocation()
        {
            return new Forest();
        }
    }

    internal class Warlock : IPlayerClass
    {
        public string GetWeapon()
        {
            return "Staff";
        }

        public string GetArmor()
        {
            return "Mantle";
        }

        public ILocation GetStartLocation()
        {
            return new Hell();
        }
    }
}
