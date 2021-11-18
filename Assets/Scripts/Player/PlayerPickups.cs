using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerPickups : MonoBehaviour
    {
        [SerializeField] private MoveForward player;
        [SerializeField] private LoseScreen loseScreen;
        [SerializeField] private WinScreen winScreen;
        [SerializeField] private AudioSource pickupSound;
        [SerializeField] private AudioSource removeSound;
        
        private static IPickupable _lastPickup;
        private int _pickupsCount;

        private void OnEnable()
        {
            _lastPickup = GetComponentInChildren<IPickupable>();
            _pickupsCount = transform.childCount;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IPickupable>()?.Pickup();
        }

        public void Add(IPickupable pickupable)
        {
            if (pickupable == null) return;
       
            pickupSound.pitch = Random.Range(0.93f, 1.07f);
            pickupSound.Play();
            
            var pickupableTransform = pickupable.GO.transform;
            
            pickupableTransform.parent = transform;
            pickupableTransform.localPosition = Vector3.Scale(transform.up, pickupableTransform.lossyScale) * _pickupsCount * 0.95f;
            pickupableTransform.localPosition = new Vector3(0, pickupableTransform.localPosition.y, 0);

            _pickupsCount = transform.childCount;
            _lastPickup.SpringJoint.connectedBody = pickupable.Rigidbody;
            _lastPickup = transform.GetChild(_pickupsCount - 1).GetComponent<IPickupable>();
        }

        public void UpdatePickups()
        {       
            removeSound.pitch = Random.Range(0.93f, 1.07f);
            removeSound.PlayOneShot(removeSound.clip);
            
            _pickupsCount = transform.childCount;

            if (_pickupsCount < 1)
            {
                if (!winScreen.enabled) loseScreen.ShowUp();

                var colliders = GetComponents<BoxCollider>();
                foreach (var boxCollider in colliders) 
                    boxCollider.enabled = false;
                transform.root.GetComponentInChildren<TrailRenderer>().emitting = false;
                player.Stop();
            }
            else
            {
                _lastPickup = transform.GetChild(_pickupsCount - 1).GetComponent<IPickupable>();
            }
        }
    }
}