using Interfaces;
using Player;
using UI.Score;
using UI.WInLose;
using UnityEngine;

namespace Cubes_On_Track
{
    public class Ladder : MonoBehaviour
    {
        [SerializeField] private PlayerPickups pickups;
        [SerializeField] private WinScreen winScreen;
        [SerializeField] private LoseScreen loseScreen;

        private IPickupable _bottomPickupable;
        private static int _scoreMultiplier;

        private void OnTriggerEnter(Collider other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            pickupable.GO.transform.parent = transform;

            if (pickups.transform.childCount > 0)
            {
                _bottomPickupable = pickups.transform.GetChild(0).gameObject.GetComponent<IPickupable>();
                _scoreMultiplier = (int) (_bottomPickupable.GO.transform.position.y + 0.1f);    
            }
            else
            {
                ShowWinScreen();
                loseScreen.gameObject.SetActive(false);
            }
        }

        public static int GetScoreMultiplier() => _scoreMultiplier;
    
        public void ShowWinScreen() => winScreen.ShowUp(_scoreMultiplier, CurrentScoreModel.Instance.CurrentValue);
    }
}
