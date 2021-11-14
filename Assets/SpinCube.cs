using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class SpinCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var pickupable = other.gameObject.GetComponent<IPickupable>();
        if (pickupable == null) return;
        
        pickupable.GO.transform.parent = transform;
    }
}
