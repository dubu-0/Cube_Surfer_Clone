using Interfaces;
using UnityEngine;

namespace Cubes_On_Track
{
    public class FloorCube : MonoBehaviour
    {
        private bool _parented;
        
        private void OnTriggerEnter(Collider other)
        {
            var pickupable = other.gameObject.GetComponent<IPickupable>();
            if (pickupable == null || _parented) return;
        
            pickupable.GO.transform.parent = transform;
            pickupable.GO.transform.localPosition -= new Vector3(0, pickupable.GO.transform.lossyScale.y * 2000, 0);
            _parented = true;
        }
    }
}
