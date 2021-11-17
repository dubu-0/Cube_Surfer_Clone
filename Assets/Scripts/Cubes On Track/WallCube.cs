using Interfaces;
using UnityEngine;

namespace Cubes_On_Track
{
    public class WallCube : MonoBehaviour
    {
        private bool _parented;
        
        private void OnTriggerEnter(Collider other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            if (pickupable == null || _parented || pickupable.GO == null) return;
        
            pickupable.GO.transform.parent = transform;
            _parented = true;
        }
    }
}
