using System;
using System.Collections;
using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    [SerializeField] private PlayerPickups pickups;

    private IPickupable _bottomPickupable;
    private static int _scoreMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        var pickupable = other.gameObject.GetComponent<IPickupable>();
        pickupable.GO.transform.parent = transform;

        if (pickups.transform.childCount > 0)
        {
            _bottomPickupable = pickups.transform.GetChild(0).gameObject.GetComponent<IPickupable>();
            _scoreMultiplier = (int) (_bottomPickupable.GO.transform.position.y + 0.1f);    
        }
        else
        {
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }

    public int GetScore() => _scoreMultiplier;

    public static IEnumerator WaitAndLoadNextLevel()
    {
        
        yield return new WaitForSeconds(1f);
        
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
