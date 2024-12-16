using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public abstract class DamageHandler
    {
        public DamageHandler NextHandler;

        public int HandleDamage(int input)
        {
            if (NextHandler != null)
            {
                return NextHandler.HandleDamage(ApplyEffect(input));
            }
            return ApplyEffect(input);
        }

        public abstract int ApplyEffect(int input);

        public void SetNextHandler(DamageHandler nextHandler)
        {
            if(NextHandler != null)
            {
                NextHandler.SetNextHandler(nextHandler);
                return;
            }
            NextHandler = nextHandler;
        }
    }

    public class StrengthDamageHandler : DamageHandler
    {
        public override int ApplyEffect(int input)
        {
            if(GameManager.Active.CurrentPlayer.Health > 60)
            {
                Console.WriteLine("Ваш урон увеличился на 20% из-за вашего здоровья!\n");
                return (int)(input * 1.2);
            }
            return input;
        }
    }

    public class SharpeningDamageHandler : DamageHandler
    {
        public override int ApplyEffect(int input)
        {
            Console.WriteLine("Ваш урон увеличился на 5 из-за заточки!\n");
            return input + 5;
        }
    }
}
