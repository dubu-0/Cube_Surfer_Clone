using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Player;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private MoveForward player;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Ladder.WaitAndLoadNextLevel());
        player.Stop();
    }
}
