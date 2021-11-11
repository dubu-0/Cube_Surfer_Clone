using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TrackCube : MonoBehaviour, IPickupable
{
    [SerializeField] private PlayerPickups pickups;

    private bool _pickedUp;

    public GameObject GO => gameObject;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IObstacle>()?.StopTrespasser(this);
    }

    public void Pickup()
    {
        if (_pickedUp) return;
        pickups.Add(this);
        _pickedUp = true;
    }
}