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
        
        public string AttackPlayer();
        public string TakeDamage(int damage);
        public void Die();
        public string Heal(int amount);

        // Ссылка на противника нужна для обработки логики элитных противников
        public string MakeTurn(IEnemy enemy);

        public delegate void EnemyDeathHandler(IEnemy enemy);
        public static event EnemyDeathHandler? AfterEnemyDeath;
    }
}
