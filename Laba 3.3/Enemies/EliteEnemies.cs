using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3.Enemies
{
    // Вместо абстрактного класса я использую интерфейсы.
    // В связи с тем, что в послдених версиях C# есть возможность
    // запихивать свойства в интерфейсы, я использую
    // наследование от интерфейса
    internal class BasicEliteEnemy : IEnemy
    {
        protected IEnemy _originalEnemy;
        
        // Благодаря интерфейсу мы не создаём лишние поля, а используем одно поле и кучу свойств
        public int Health { get { return _originalEnemy.Health; } }
        public int Damage { get { return _originalEnemy.Damage; } }
        public int Level { get { return _originalEnemy.Level; } }
        public string Name { get { return _originalEnemy.Name; } }

        public virtual int AttackPlayer() => _originalEnemy.AttackPlayer();

        public virtual void Die() => _originalEnemy.Die();

        public virtual int TakeDamage(int damage) => _originalEnemy.TakeDamage(damage);

        public virtual int Heal(int healAmount) => _originalEnemy.Heal(healAmount);

        internal BasicEliteEnemy(IEnemy originalEnemy)
        {
            this._originalEnemy = originalEnemy;
        }
    }

    internal class TornedEnemy : BasicEliteEnemy
    {
        TornedEnemy(IEnemy originalEnemy) : base(originalEnemy) { }

        override public int TakeDamage(int damage)
        {
            int output = base.TakeDamage(damage);
            int playerDamage = damage / 2;
            Console.WriteLine($"{Name} колит вас своими колючками на {playerDamage} урона!");
            WorldStatus.GetActive().CurrentPlayer.Health -= playerDamage;
            if(WorldStatus.GetActive().CurrentPlayer.Health <= 1)
            {
                // Player Death
            }
            return output;
        }
    }

    internal class VampiricEnemy : BasicEliteEnemy
    {
    VampiricEnemy(IEnemy originalEnemy) : base(originalEnemy) { }

        public override int AttackPlayer()
        {
            int output = base.AttackPlayer();
            Heal(output);
            return output;
        }
    }
}
