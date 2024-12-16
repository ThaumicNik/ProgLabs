using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class ArmorItem : GameItem
    {
        public int Protection;

        public ArmorItem() : base() 
        { 
            Protection = 0;
        }
    }

    public class PlateArmor : ArmorItem
    {
        public PlateArmor()
        {
            Name = "Латы";
            Protection = 3;
        }
    }

    public class LeatherArmor : ArmorItem
    {
        public LeatherArmor()
        {
            Name = "Кожанный доспех";
            Protection = 2;
        }
    }

    public class ClothRobe : ArmorItem
    {
        public ClothRobe()
        {
            Name = "Тканевая роба";
            Protection = 1;
        }
    }
}
