using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class Warrior : IPlayerClass
    {
        public WeaponItem GetWeapon()
        {
            return new Longsword();
        }

        public ArmorItem GetArmor()
        {
            return new PlateArmor();
        }

    }

    public class Rogue : IPlayerClass
    {
        public WeaponItem GetWeapon()
        {
            return new Bow();
        }

        public ArmorItem GetArmor()
        {
            return new LeatherArmor();
        }
    }

    public class Warlock : IPlayerClass
    {
        public WeaponItem GetWeapon()
        {
            return new Staff();
        }
        public ArmorItem GetArmor()
        {
            return new ClothRobe();
        }
    }
}
