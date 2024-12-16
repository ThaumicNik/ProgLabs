using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public static class EasyPlayerGenerator
    {
        public static Player BuildRandom()
        {
            Player.PlayerBuilder builder = new Player.PlayerBuilder();
            builder.SetName($"Персонаж {GameManager.GetRandomInt(0, 9999)}");
            builder.SetMoney(GameManager.GetRandomInt(0, 2000));
            builder.SetHealth(GameManager.GetRandomInt(0, 100));
            IPlayerClass playerClass;
            switch (GameManager.GetRandomInt(1, 3))
            {
                case 1:
                    playerClass = new Warrior();
                    break;
                case 2:
                    playerClass = new Rogue();
                    break;
                default:
                    playerClass = new Warlock();
                    break;
            }
            builder.SetClass(playerClass);
            return builder.Build();
        }
    }
}
