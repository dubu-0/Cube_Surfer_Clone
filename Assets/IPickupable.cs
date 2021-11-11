using UnityEngine;

public interface IPickupable
{
    public GameObject GO { get; }

    public void Pickup();
}