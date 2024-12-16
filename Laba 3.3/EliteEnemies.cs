using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    // Вместо абстрактного класса я использую интерфейсы.
    // В связи с тем, что в послдених версиях C# есть возможность
    // запихивать свойства в интерфейсы, я использую
    // наследование от интерфейса
    public class BasicEliteEnemy : IEnemy
    {
        protected IEnemy _originalEnemy;
        
        // Благодаря интерфейсу мы не создаём лишние поля, а используем одно поле и кучу свойств
        public virtual int Health { get { return _originalEnemy.Health; } }
        public virtual int Damage { get { return _originalEnemy.Damage; } }
        public virtual int Level { get { return _originalEnemy.Level; } }
        public virtual string Name { get { return _originalEnemy.Name; } }

        public virtual string AttackPlayer() => _originalEnemy.AttackPlayer();

        public virtual void Die() => _originalEnemy.Die();

        public virtual string TakeDamage(int damage) => _originalEnemy.TakeDamage(damage);

        public virtual string Heal(int healAmount) => _originalEnemy.Heal(healAmount);

        public virtual string MakeTurn(IEnemy enemy) => _originalEnemy.MakeTurn(enemy);

        public BasicEliteEnemy(IEnemy originalEnemy)
        {
            this._originalEnemy = originalEnemy;
        }
    }

    public class TornedEnemy : BasicEliteEnemy
    {
        public TornedEnemy(IEnemy originalEnemy) : base(originalEnemy) { }

        public override string Name { get { return $"Шипастый {_originalEnemy.Name}"; } }

        override public string TakeDamage(int damage)
        {
            string output = base.TakeDamage(damage);
            int playerDamage = damage / 2;
            output += $"\n\n{Name} колит вас своими шипами на {playerDamage} урона!";
            GameManager.GetActive().CurrentPlayer.Health -= playerDamage;
            if(GameManager.GetActive().CurrentPlayer.Health <= 1)
            {
                GameManager.GetActive().State = "PlayerDied";
            }
            return output;
        }
    }
    public class VampiricEnemy : BasicEliteEnemy
    {
        public VampiricEnemy(IEnemy originalEnemy) : base(originalEnemy) { }

        public override string AttackPlayer()
        {
            string output = base.AttackPlayer();
            Heal(Damage/3);
            return output + $"\n\n{Name} лечится за счёт вашей крови на {Damage / 3} здоровья!";
        }

        public override string Name { get { return $"Вампирический {_originalEnemy.Name}"; } }
    }
}
