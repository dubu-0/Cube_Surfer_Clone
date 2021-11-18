using Player;
using UnityEngine;

namespace Track
{
    public class Turner : MonoBehaviour
    {
        [SerializeField] private Vector3 newRotationEuler;

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

            var rotation = playerRoot.rotation;
            rotation.eulerAngles = newRotationEuler;
            playerRoot.rotation = rotation;

            _turned = true;
            enabled = false;
        }
    }
}
