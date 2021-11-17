using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Text textComponent;

        private void OnEnable() => ScoreModel.Instance.OnScoreChanged += UpdateText;
        private void OnDisable() => ScoreModel.Instance.OnScoreChanged -= UpdateText;
        private void OnDestroy() => ScoreModel.Instance.ToDefault();
        private void UpdateText() => textComponent.text = ScoreModel.Instance.CurrentValue.ToString();
    }
}