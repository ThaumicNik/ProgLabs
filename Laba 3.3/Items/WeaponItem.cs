using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public abstract class WeaponItem : GameItem
    {
        public int Damage;

        public WeaponItem() : base()
        {
            Damage = 0;
        }
    }

    public class Longsword : WeaponItem
    {
        public Longsword()
        {
            Name = "Длинный меч";
            Damage = 15;
        }
    }

    public class Bow : WeaponItem
    {
        public Bow()
        {
            Name = "Лук";
            Damage = 25;
        }
    }

    public class Staff : WeaponItem
    {
        public Staff()
        {
            Name = "Посох";
            Damage = 40;
        }
    }
}
