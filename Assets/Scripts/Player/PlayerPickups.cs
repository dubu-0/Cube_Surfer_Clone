using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerPickups : MonoBehaviour
    {
        private static IPickupable _lastPickup;
        private readonly Queue<IPickupable> _pickups = new Queue<IPickupable>();

        private void Start()
        {
            _lastPickup = GetComponentInChildren<IPickupable>();
            _pickups.Enqueue(_lastPickup);
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IPickupable>()?.Pickup();
        }

        public void Add(IPickupable pickupable)
        {
            pickupable.GO.transform.parent = transform;
            pickupable.GO.transform.localPosition += Vector3.Scale(Vector3.up, pickupable.GO.transform.lossyScale) * _pickups.Count;
            pickupable.GO.transform.localPosition = new Vector3(0, pickupable.GO.transform.localPosition.y, 0);
            _lastPickup.SpringJoint.connectedBody = pickupable.Rigidbody;
            _lastPickup = pickupable;
            _pickups.Enqueue(pickupable);
        }

        public void Remove()
        {
            _pickups.Dequeue();
        }
    }
}