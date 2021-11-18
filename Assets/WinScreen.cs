using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Text scoreMultiplier;
    [SerializeField] private Text currentScore;

    public void ShowUp(int multiplier, int curScore)
    {
        gameObject.SetActive(true);
        scoreMultiplier.text = $"{multiplier}X";
        currentScore.text = (curScore * multiplier).ToString();
    }
}