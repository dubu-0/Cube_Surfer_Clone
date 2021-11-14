using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerPickups : MonoBehaviour
    {
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
            Debug.Log(_pickupsCount);
        }

        public void Add(IPickupable pickupable)
        {
            if (pickupable == null) return;

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
            _pickupsCount = transform.childCount;

            Debug.Log(_pickupsCount + " after remove");

            if (_pickupsCount < 1)
            {
                Debug.Log("You Lost");
            }
            else
            {
                _lastPickup = transform.GetChild(_pickupsCount - 1).GetComponent<IPickupable>();
            }
        }
    }
}