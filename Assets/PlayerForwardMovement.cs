using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 10;
    
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;   
    }
}
