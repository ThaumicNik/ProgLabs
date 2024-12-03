namespace Laba_3._3
{
    public class WorldStatus
    {
        public static WorldStatus Active { get { return GetActive(); } }
        private static WorldStatus _active;

        private int _year = 1000;
        private string _season = "Autumn";
        public Player CurrentPlayer { get; set; }

        public static WorldStatus GetActive()
        {
            if(_active == null)
                _active = new WorldStatus();
            return _active;
        }

        private WorldStatus() { }

        public void Show()
        {
            Console.WriteLine($"Year: {_year}\nSeason: {_season}\n");
        }

        public static string MakeChoice(string message,List<string> options)
        {
            while (true)
            {
                Console.WriteLine(message);
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($" {i}) {options[i]}");
                }
                string input = Console.ReadLine();
                for (int i = 0; i < options.Count; i++)
                {
                    if(input == i.ToString() || input == options[i])
                    {
                        Console.Clear();
                        return options[i];
                    }
                }
                Console.Clear();
            }
        }

        internal static void ClassSetup()
        {
            Player.PlayerBuilder playerBuilder = new Player.PlayerBuilder();
            playerBuilder.SetName("Константа");
            switch (WorldStatus.MakeChoice("Выберите класс:", new List<string>
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
            WorldStatus.Active.CurrentPlayer = playerBuilder.Build();
        }
    }
}
