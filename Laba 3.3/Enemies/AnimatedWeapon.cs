using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class AnimatedWeapon : BasicEnemy
    {
        private WeaponItem _weapon;
        public AnimatedWeapon()
        {
            switch (GameManager.GetRandomInt(1, 3))
            {
                case 1:
                    _weapon = new Longsword();
                    break;
                case 2:
                    _weapon = new Bow();
                    break;
                default:
                    _weapon = new Staff();
                    break;
            }
            _name = $"Летающий {_weapon.Name}";
            _damage = _weapon.Damage;
            _level = 5;
            _health = 25;
            _ai = new AIAttackNHeal();
        }
    }
}
