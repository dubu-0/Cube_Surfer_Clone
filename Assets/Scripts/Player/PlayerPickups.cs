using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerPickups : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IPickupable>()?.Pickup();
        }

        public void Add(IPickupable pickup)
        {
            MovePlayerUp(pickup.GO.transform.lossyScale.y);
            pickup.GO.transform.parent = transform;
            pickup.GO.transform.localPosition = new Vector3(0, pickup.GO.transform.localPosition.y, 0);
        }

        private void MovePlayerUp(float y) => transform.root.position += new Vector3(0, y, 0);
    }
}