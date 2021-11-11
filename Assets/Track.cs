using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Track : MonoBehaviour
{
    private BoxCollider _myCollider;
    private float _leftBoundary;
    private float _rightBoundary;

    private void Start()
    {
        _myCollider = GetComponent<BoxCollider>();
        _leftBoundary = _myCollider.bounds.min.x;
        _rightBoundary = _myCollider.bounds.max.x;
    }

    public (float, float) GetBoundaries() => (_leftBoundary, _rightBoundary);
}
