using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public interface IEnemy
    {
        public int Health { get; }
        public string Name { get; }
        public int Level { get; }
        public int Damage { get; }

        public int AttackPlayer();
        public int TakeDamage(int damage);
        public void Die();
        public int Heal(int amount);
    }
}
