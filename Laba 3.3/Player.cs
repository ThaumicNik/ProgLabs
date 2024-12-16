namespace Laba_3._3
{
    public class Player
    {
        public string Name;
        public int Money;
        public ArmorItem Armor;
        public WeaponItem Weapon;
        public Ring? Ring;
        public int Health;

        public Player(PlayerBuilder builder)
        {
            this.Name = builder._name;
            this.Money = builder.Money;
            this.Armor = builder.PlayerClass.GetArmor();
            this.Weapon = builder.PlayerClass.GetWeapon();
            this.Health = builder.Health;
        }

        public void ShowPlayerStatus()
        {
            Console.WriteLine($"Имя: {Name}\n Здоровье: {Health} \n Золото: {Money}\n Броня: {Armor.Name} (ЗАЩ: {Armor.Protection})\n Оружие: {Weapon.Name} (АТК: {Weapon.Damage})\n");
            if(Ring != null)
            {
                Console.WriteLine($"Вы используете {Ring.Name}");
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public class PlayerBuilder
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
                PlayerClass = new Warrior();
            }
        }
    }

}
