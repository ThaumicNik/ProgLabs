using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    internal interface IPlayerClass
    {
        string GetWeapon();

        string GetArmor();

        ILocation GetStartLocation();
    }
}
