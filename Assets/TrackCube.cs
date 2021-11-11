using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TrackCube : MonoBehaviour, IPickupable
{
    [SerializeField] private PlayerPickups pickups;

    private bool _pickedUp;
    
    public GameObject GO => gameObject;

    public void Pickup()
    {
        if (_pickedUp) return;
        pickups.Add(this);
        _pickedUp = true;
    }
}