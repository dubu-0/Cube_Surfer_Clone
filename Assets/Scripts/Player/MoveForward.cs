using UnityEngine;

namespace Player
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private Vector3 velocity;

        private void Update()
        {
            transform.position += velocity * Time.deltaTime;
        }
    }
}
