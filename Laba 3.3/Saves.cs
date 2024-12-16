using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public static class SaveSystem
    {
        // Мне лень делать БД, потому сделаю два списка сохранений, удалённый и локальный
        public static Dictionary<string, Save> ExternalSaves = new Dictionary<string, Save>();
        public static Dictionary<string, Save> LocalSaves = new Dictionary<string, Save>();
        public static bool Initialized = false;

        public static void Initialize()
        {
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            ExternalSaves.Add($"Перс{GameManager.GetRandomInt(1, 500)}", new Save(EasyPlayerGenerator.BuildRandom()));
            Initialized = true;
        }

        public static List<string> GetSaveNames()
        {
            if (!Initialized)
            {
                Initialize();
            }
            return ExternalSaves.Keys.ToList();
        }

        public static void LoadSave(string saveName)
        {
            if (LocalSaves.ContainsKey(saveName))
            {
                GameManager.GetActive().CurrentPlayer = LocalSaves[saveName].SavedPlayer;
                Console.WriteLine("Сохранение загружено из локального хранилища.");
            }
            else if (ExternalSaves.ContainsKey(saveName))
            {
                LocalSaves.Add(saveName, ExternalSaves[saveName]);
                GameManager.GetActive().CurrentPlayer = ExternalSaves[saveName].SavedPlayer;
                Console.WriteLine("Сохранение загружено из внешнего хранилища.");
            }
            Console.WriteLine("\nНажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }
    }

    public class Save
    {
        public Player SavedPlayer;
        public DateTime CreationDate;

        public Save(Player savedPlayer)
        {
            SavedPlayer = savedPlayer;
            CreationDate = DateTime.Now;
        }
    }
}
