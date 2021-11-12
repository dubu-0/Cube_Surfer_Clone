using UnityEngine;

namespace Player
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Vector3 velocity;

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + velocity);
        }
    }
}
