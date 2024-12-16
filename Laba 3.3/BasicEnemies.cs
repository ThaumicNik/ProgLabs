using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Laba_3._3.IEnemy;

namespace Laba_3._3
{
    public abstract class BasicEnemy : IEnemy
    {
        protected int _health;
        protected int _level;
        protected int _damage;
        protected string _name;
        protected IEnemyAI _ai;

        public virtual int Health { get { return _health; } }
        public virtual int Level { get { return _level; } }
        public virtual string Name { get { return _name; } }
        public virtual int Damage { get { return _damage; } }

        public string AttackPlayer()
        {
            if (GameManager.GetActive().CurrentPlayer == null)
                return "";
            int finalDamage = _damage / GameManager.GetActive().CurrentPlayer.Armor.Protection;
            GameManager.GetActive().CurrentPlayer.Health -= finalDamage;
            if(GameManager.GetActive().CurrentPlayer.Health <= 0)
            {
                GameManager.GetActive().State = "PlayerDied";
                GameManager.GetActive().CurrentPlayer.ShowPlayerStatus();
            }
            return $"{Name} атакует вас, нанеся {finalDamage} урона!";
        }

        public void Die()
        {
            GameManager.GetActive().State = "PlayerWin";
        }

        public string TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Die();
            }
            return $"Вы наносите {damage} урона {Name}.";
        }

        public string Heal(int healAmount)
        {
            _health += healAmount;
            return $"{Name} лечит себя на {healAmount} единиц здоровья.";
        }

        public string MakeTurn(IEnemy enemy)
        {
            return _ai.MakeTurn(enemy);
        }

        public BasicEnemy()
        {
            _health = 0;
            _level = 0;
            _damage = 0;
            _name = "I'M AN ERROR";
            _ai = new AIStupidAttack();
        }
    }

    public class Goblin : BasicEnemy
    {
        public Goblin()
        {
            _health = 50;
            _level = 1;
            _damage = 5;
            _name = "Гоблин";
            _ai = new AIStupidAttack();
        }
    }

    public class Devil : BasicEnemy
    {
        public Devil()
        {
            _health = 100;
            _level = 5;
            _damage = 20;
            _name = "Дьявол";
            _ai = new AIAttackNHeal();
        }
    }

    public class Skeleton : BasicEnemy
    {
        public Skeleton()
        {
            _health = 60;
            _level = 2;
            _damage = 10;
            _name = "Скелет";
            _ai = new AIStupidAttack();
        }
    }
}
