using System;

namespace UI.Score
{
    public class CurrentScoreModel
    {
        private CurrentScoreModel() { }

        public static CurrentScoreModel Instance { get; } = new CurrentScoreModel();
        
        public int CurrentValue { get; private set; }

        public event Action OnScoreChanged;

        public void Add(int value)
        {
            CurrentValue += value;
            OnScoreChanged?.Invoke();
        }

        public void ToDefault()
        {
            CurrentValue = 0;
            OnScoreChanged?.Invoke();
        }
    }
}