using System;

namespace Klyukay.CoreLogic
{
    
    public sealed class GameManager
    {

        private static GameManager instance;

        public static GameManager Instance => instance ??= new GameManager();

        public readonly Car Car;

        private bool gameStarted;
        
        private GameManager()
        {
            gameStarted = false;
            
            Car = new Car();
            Car.CarDestroyed += OnCarDestroyed;
        }

        public event Action GameEnd;

        public bool StartGame()
        {
            if (gameStarted) return false;

            Car.Reset();
            
            gameStarted = true;
            return true;
        }

        private void OnCarDestroyed()
        {
            gameStarted = false;
            GameEnd?.Invoke();
        }
    }
    
}