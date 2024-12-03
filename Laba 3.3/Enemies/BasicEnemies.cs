using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3.Enemies
{
    internal abstract class BasicEnemy : IEnemy
    {
        protected int _health;
        protected int _level;
        protected int _damage;
        protected string _name;

        public int Health { get { return _health; } }
        public int Level { get { return _level; } }
        public string Name { get { return _name; } }
        public int Damage { get { return _damage; } }

        public int AttackPlayer()
        {
            if (WorldStatus.GetActive().CurrentPlayer == null)
                return 0;
            WorldStatus.GetActive().CurrentPlayer.Health -= _damage;
            if(WorldStatus.GetActive().CurrentPlayer.Health <= 0)
            {
                // TODO Death
                WorldStatus.GetActive().CurrentPlayer.ShowPlayerStatus();
            }
            return _damage;
        }

        public void Die()
        {
            Console.WriteLine($"{_name} dies.");
        }

        public int TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Die();
            }
            return damage;
        }

        public int Heal(int healAmount)
        {
            _health += healAmount;
            return healAmount;
        }

        internal BasicEnemy()
        {
            _health = 0;
            _level = 0;
            _damage = 0;
            _name = "I'M AN ERROR";
        }
    }

    internal class Goblin : BasicEnemy
    {
        internal Goblin()
        {
            _health = 50;
            _level = 1;
            _damage = 5;
            _name = "Goblin";
        }
    }

    internal class Devil : BasicEnemy
    {
        internal Devil()
        {
            _health = 100;
            _level = 5;
            _damage = 20;
            _name = "Devil";
        }
    }

    internal class Skeleton : BasicEnemy
    {
        internal Skeleton()
        {
            _health = 60;
            _level = 2;
            _damage = 10;
            _name = "Skeleton";
        }
    }
}
