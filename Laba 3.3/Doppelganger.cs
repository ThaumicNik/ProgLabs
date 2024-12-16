using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class Doppelganger : BasicEnemy
    {
        private Player _mimicTo;
        public Doppelganger()
        {
            _mimicTo = GameManager.GetActive().CurrentPlayer;
            _name = _mimicTo.Name;
            _health = 10 * _mimicTo.Armor.Protection;
            _damage = _mimicTo.Weapon.Damage;
            _level = 10;
            _ai = new AIAttackNHeal();
        }
    }
}
