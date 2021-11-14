using Player;
using UnityEngine;

public class Turner : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private Track.Track next;

    private bool _turned;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerPickups>();
        if (player == null || _turned) return;
        
        var playerRoot = player.gameObject.transform.root;
        playerRoot.parent = transform;
        
        var rootLocalPos = playerRoot.localPosition;
        rootLocalPos.x = 0;
        rootLocalPos.z = 0;

        playerRoot.localPosition = rootLocalPos;
        playerRoot.parent = null;
        playerRoot.forward = direction;

        _turned = true;
        enabled = false;
    }
}
