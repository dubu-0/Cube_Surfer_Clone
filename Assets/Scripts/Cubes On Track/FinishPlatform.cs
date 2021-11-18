using Player;
using UI.Score;
using UI.WInLose;
using UnityEngine;

namespace Cubes_On_Track
{
    public class FinishPlatform : MonoBehaviour
    {
        [SerializeField] private MoveForward player;
        [SerializeField] private WinScreen winScreen;
        [SerializeField] private LoseScreen loseScreen;
    
        private void OnTriggerEnter(Collider other)
        {
            winScreen.ShowUp(Ladder.GetScoreMultiplier(), CurrentScoreModel.Instance.CurrentValue);
            loseScreen.gameObject.SetActive(false);
            player.Stop();
        }
    }
}
