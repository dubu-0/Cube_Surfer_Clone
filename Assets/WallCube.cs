using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCube : MonoBehaviour, IObstacle
{
    public void StopTrespasser(IPickupable other)
    {
        other.GO.transform.parent = transform;
    }
}
