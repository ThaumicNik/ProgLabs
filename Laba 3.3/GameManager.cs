namespace Laba_3._3
{
    public class GameManager
    {
        public static GameManager Active { get { return GetActive(); } }
        private static GameManager _active = new GameManager();

        private static Random _random = new Random();
        public Player CurrentPlayer { get; set; }

        public string State { get; set; }

        public static GameManager GetActive()
        {
            if(_active == null)
                _active = new GameManager();
            return _active;
        }

        GameManager() 
        {
            CurrentPlayer = EasyPlayerGenerator.BuildRandom();
            State = "Started";
        }

        public static int GetRandomInt(int min, int max)
        {
            if(_random == null)
            {
                _random = new Random();
            }
            return min + ( _random.Next() % max);
        }

        public static string MakeChoice(string message,List<string> options)
        {
            while (true)
            {
                Console.WriteLine(message);
                for (int i = 1; i <= options.Count; i++)
                {
                    Console.WriteLine($" {i}) {options[i-1]}");
                }
                // Чтобы не ругалось на null
                string input = "" + Console.ReadLine();
                for (int i = 1; i <= options.Count; i++)
                {
                    if(input == i.ToString() || input == options[i-1])
                    {
                        Console.Clear();
                        return options[i-1];
                    }
                }
                Console.Clear();
            }
        }

        public static void ClassSetup()
        {
            Player.PlayerBuilder playerBuilder = new Player.PlayerBuilder();
            playerBuilder.SetName("Константа");
            playerBuilder.SetHealth(100);
            switch (GameManager.MakeChoice("Выберите класс:", new List<string>
            {
                "Воин",
                "Разбойник",
                "Заклинатель"
            }))
            {
                case "Воин":
                    playerBuilder.SetClass(new Warrior());
                    break;
                case "Разбойник":
                    playerBuilder.SetClass(new Rogue());
                    break;
                case "Заклинатель":
                    playerBuilder.SetClass(new Warlock());
                    break;
            }
            GameManager.Active.CurrentPlayer = playerBuilder.Build();
            GameManager.Active.State = "Started";
        }

        public static void MainMenu()
        {
            Console.Clear();
            switch (GameManager.MakeChoice("Выберите опцию", new List<string>
            {
                "Статус персонажа",
                "Начать бой",
                "Загрузить сохранение",
                "Выход"
            }))
            {
                case "Статус персонажа":
                    GameManager.Active.CurrentPlayer.ShowPlayerStatus();
                    break;
                case "Начать бой":
                    StartRaid();
                    break;
                case "Загрузить сохранение":
                    SaveMenu();
                    break;
                case "Выход":
                    GameManager.Active.State = "Quit";
                    break;
            }
        }

        public static void StartRaid()
        {
            Console.Clear();
            switch (GameManager.MakeChoice("Куда отправиться?", new List<string>
            {
                "Лес",
                "Подземелья",
                "Преисподня",
                "Выход"
            }))
            {
                case "Лес":
                    StartFight(new Forest());
                    break;
                case "Подземелья":
                    StartFight(new Dungeon());
                    break;
                case "Преисподня":
                    StartFight(new Hell());
                    break;
                case "Выход":
                    break;
            }
        }

        public static void StartFight(ILocation location)
        {
            GetActive().State = "Fight";
            Console.Clear();
            IEnemy enemy = location.SpawnEnemy();
            if(GetRandomInt(1, 2) > 1)
            {
                if (GetRandomInt(1, 3) > 1)
                {
                    enemy = new TornedEnemy(enemy);
                }
                else
                {
                    enemy = new VampiricEnemy(enemy);
                }
            }

            Console.WriteLine($"На вас напал {enemy.Name}!\n\nНажмите клавишу для того чтобы вступить в бой...");
            Console.ReadKey();
            while (GetActive().State == "Fight")
            {
                PrintFightStatus(enemy);
            }
            switch (GetActive().State)
            {
                case "PlayerDied":
                    Console.Clear();
                    Console.WriteLine("Вы умерли! Увы!\n");
                    Console.WriteLine("Нажмите любую клавишу чтобы выйти...");
                    Console.ReadKey();
                    GetActive().State = "Quit";
                    break;
                case "PlayerWin":
                    Console.Clear();
                    Console.WriteLine($"Вы победили и получили {enemy.Level} монет!\n");
                    GetActive().CurrentPlayer.Money += enemy.Level;
                    Console.WriteLine("Нажмите любую клавишу чтобы выйти из боя...");
                    Console.ReadKey();
                    GetActive().State = "Started";
                    break;
            }
        }

        public static void PrintFightStatus(IEnemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"Вы сражаетесь с {enemy.Name} [{enemy.Level} УР.]\n Здоровье: {enemy.Health}\n Урон: {enemy.Damage}\n");
            Console.WriteLine($"Ваши характеристики:\n Здоровье: {_active.CurrentPlayer.Health}\n Броня: {_active.CurrentPlayer.Armor.Name} (ЗАЩ: {_active.CurrentPlayer.Armor.Protection})\n Оружие: {_active.CurrentPlayer.Weapon.Name} (АТК: {_active.CurrentPlayer.Weapon.Damage})\n");
            switch (GameManager.MakeChoice("Куда делать?", new List<string>
            {
                "Атаковать",
                "Бежать"
            }))
            {
                case "Атаковать":
                    ProceedAttack(enemy);
                    break;
                case "Бежать":
                    GetActive().State = "Started";
                    break;
            }
        }

        public static void ProceedAttack(IEnemy enemy)
        {
            Console.Clear();
            Console.WriteLine(enemy.TakeDamage(GetActive().CurrentPlayer.Weapon.Damage) + "\n");
            Console.WriteLine(enemy.MakeTurn(enemy) + "\n");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static void SaveMenu()
        {
            string saveToLoad = GameManager.MakeChoice("Какое сохранение загрузить?", SaveSystem.GetSaveNames());
            Console.Clear();
            SaveSystem.LoadSave(saveToLoad);
        }
    }
}
