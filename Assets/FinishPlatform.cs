using Player;
using Score;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private MoveForward player;
    [SerializeField] private WinScreen winScreen;
    
    private void OnTriggerEnter(Collider other)
    {
        winScreen.ShowUp(Ladder.GetScoreMultiplier(), ScoreModel.Instance.CurrentValue);
        player.Stop();
    }
}
