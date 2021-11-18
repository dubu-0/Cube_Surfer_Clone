using UI.Score;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WInLose
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Text scoreMultiplier;
        [SerializeField] private Text currentScore;
        [SerializeField] private TotalScoreView totalScoreView;

        public void ShowUp(int multiplier, int curScore)
        {
            gameObject.SetActive(true);
            scoreMultiplier.text = $"{multiplier}X";
            currentScore.text = (curScore * multiplier).ToString();
            totalScoreView.AddAtFinish(curScore * multiplier);
        }
    }
}