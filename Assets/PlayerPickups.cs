using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    private readonly Stack<IPickupable> _pickups = new Stack<IPickupable>();

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IPickupable>()?.Pickup();
    }

    public void Add(IPickupable pickup)
    {
        MovePlayerUp(pickup.GO.transform.lossyScale.y);
        pickup.GO.transform.parent = transform;
        pickup.GO.transform.localPosition = new Vector3(0, pickup.GO.transform.localPosition.y, 0);
        _pickups.Push(pickup);
    }

    private void MovePlayerUp(float y) => transform.root.position += new Vector3(0, y, 0);
}