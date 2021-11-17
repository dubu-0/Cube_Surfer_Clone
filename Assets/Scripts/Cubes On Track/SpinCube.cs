using Interfaces;
using UnityEngine;

namespace Cubes_On_Track
{
    public class SpinCube : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            if (pickupable == null || pickupable.GO == null) return;
        
            pickupable.GO.transform.parent = transform;
        }
    }
}
