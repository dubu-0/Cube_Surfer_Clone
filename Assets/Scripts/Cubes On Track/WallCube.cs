using Interfaces;
using UnityEngine;

namespace Cubes_On_Track
{
    public class WallCube : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            if (pickupable == null) return;
        
            pickupable.GO.transform.parent = transform;
        }
    }
}
