using Interfaces;
using Player;
using UnityEngine;

namespace Cubes_On_Track
{
    [RequireComponent(typeof(BoxCollider))]
    public class TrackCube : MonoBehaviour, IPickupable
    {
        [SerializeField] private PlayerPickups pickups;

        private bool _pickedUp;

        public GameObject GO => gameObject;

        private void OnCollisionEnter(Collision other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            pickupable?.Pickup();
        }

        public void Pickup()
        {
            if (_pickedUp) return;
            pickups.Add(this);
            _pickedUp = true;
        }
    }
}