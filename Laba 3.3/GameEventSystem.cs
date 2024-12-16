using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3._3
{
    public enum GameEvent { FIGHT_START, FIGHT_END }

    public interface IObserver
    {
        public void OnCall();
    }

    public static class GameEventSystem
    {
        private static Dictionary<GameEvent, List<IObserver>> _observers = new();

        public static void AddObserver(GameEvent type, IObserver observer)
        {
            if (!_observers.ContainsKey(type))
            {
                _observers[type] = new List<IObserver>();
            }
            _observers[type].Add(observer);
        }

        public static void RemoveObserver(GameEvent type, IObserver observer)
        {
            if (_observers.ContainsKey(type))
            {
                _observers[type].Remove(observer);
            }
        }

        public static void CallObservers(GameEvent type)
        {
            if (_observers.ContainsKey(type))
            {
                foreach (var observer in _observers[type])
                {
                    observer.OnCall();
                }
            }
        }
    }
}
