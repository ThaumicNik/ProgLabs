using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public interface IEnemyAI
    {
        public string MakeTurn(IEnemy enemy);
    }

    // Тупо спамит атаку
    public class AIStupidAttack : IEnemyAI
    {
        public string MakeTurn(IEnemy enemy)
        {
            return enemy.AttackPlayer();
        }
    }

    // Чередует две атаки и один хилл на 10
    public class AIAttackNHeal : IEnemyAI
    {
        private int turn = 0;
        public string MakeTurn(IEnemy enemy)
        {
            string output;
            if (turn % 3 == 2)
            {
                output = enemy.Heal(10);
            }
            else 
            {
                output = enemy.AttackPlayer();
            }
            turn++;
            return output;
        }
    }
}
