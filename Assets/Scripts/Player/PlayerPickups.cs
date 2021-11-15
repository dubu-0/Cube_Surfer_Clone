using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerPickups : MonoBehaviour
    {
        [SerializeField] private AudioSource pickupSound;
        [SerializeField] private AudioSource removeSound;
        
        private static IPickupable _lastPickup;
        private int _pickupsCount;
        private Camera _main;

        private void OnEnable()
        {
            _main = Camera.main;
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

            Handheld.Vibrate();
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
            Handheld.Vibrate();
            removeSound.pitch = Random.Range(0.93f, 1.07f);
            removeSound.PlayOneShot(removeSound.clip);
            
            _pickupsCount = transform.childCount;

            if (_pickupsCount < 1)
            {
                StartCoroutine(WaitAndRestartCurrentScene());
            }
            else
            {
                _lastPickup = transform.GetChild(_pickupsCount - 1).GetComponent<IPickupable>();
            }
        }

        private IEnumerator WaitAndRestartCurrentScene()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}