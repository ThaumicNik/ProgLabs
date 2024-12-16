using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public abstract class Ring : GameItem, IObserver
    {
        public abstract void OnEquip();
        public abstract void OnCall();
    }

    public class HolyRing : Ring
    {
        public HolyRing()
        {
            Name = "Святое кольцо (+5 ХП в начале боя)";
        }

        public override void OnEquip()
        {
            GameEventSystem.AddObserver(GameEvent.FIGHT_START, this);
        }

        public override void OnCall() 
        {
            GameManager.GetActive().CurrentPlayer.Health += 5;
        }
    }

    public class GreedRing : Ring
    {
        public GreedRing()
        {
            Name = "Кольцо жадности (+2 ЗОЛ в конце боя)";
        }

        public override void OnEquip()
        {
            GameEventSystem.AddObserver(GameEvent.FIGHT_END, this);
        }

        public override void OnCall()
        {
            GameManager.GetActive().CurrentPlayer.Money -= 2;
        }
    }
}
