using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Score
{
    public class TotalScoreView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private const string Key = nameof(TotalScoreView);
        private static int _total;

        private void OnEnable()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                _total = PlayerPrefs.GetInt(Key);
                UpdateText();
            }

            CurrentScoreModel.Instance.OnScoreChanged += Add;
        }

        private void OnDisable() => CurrentScoreModel.Instance.OnScoreChanged -= Add;
        private void OnDestroy() => CurrentScoreModel.Instance.ToDefault();

        public void AddAtFinish(int value)
        {
            _total += value;
            PlayerPrefs.SetInt(Key, _total);
            UpdateText();
        }

        private void Add()
        {
            _total += 1;
            UpdateText();
        }

        private void UpdateText() => textComponent.text = _total.ToString();
    }
}