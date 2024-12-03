using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public class Player
    {
        public string Name;
        public int Money;
        public string Armor;
        public string Weapon;
        public int Health;
        internal ILocation Location;

        internal Player(PlayerBuilder builder)
        {
            this.Name = builder._name;
            this.Money = builder.Money;
            this.Armor = builder.PlayerClass.GetArmor();
            this.Weapon = builder.PlayerClass.GetWeapon();
            this.Health = builder.Health;
            this.Location = builder.PlayerClass.GetStartLocation();
            WorldStatus.GetActive().CurrentPlayer = this;
        }

        public void ShowPlayerStatus()
        {
            Console.WriteLine($"Name: {Name}\n Money {Money}\n Armor {Armor}\n Weapon {Weapon}\n Health {Health}\n\nNext enemy: {Location.SpawnEnemy()}\n\n");
        }

        internal class PlayerBuilder
        {
            public string _name;
            public int Money;
            public IPlayerClass PlayerClass;
            public int Health;

            public PlayerBuilder SetName(string name)
            {
                this._name = name;
                return this;
            }

            public PlayerBuilder SetMoney(int money)
            {
                this.Money = money;
                return this;
            }

            public PlayerBuilder SetClass(IPlayerClass playerClass)
            {
                this.PlayerClass = playerClass;
                return this;
            }

            public PlayerBuilder SetHealth(int health)
            {
                this.Health = health;
                return this;
            }

            public Player Build()
            {
                return new Player(this);
            }

            public PlayerBuilder()
            {
                _name = "";
            }
        }
    }

}
