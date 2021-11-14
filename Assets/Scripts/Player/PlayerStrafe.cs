using UnityEngine;

namespace Player
{
    public class PlayerStrafe : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Track.Track track;

        private const string Horizontal = nameof(Horizontal);

        private void Update()
        {
            Strafe(Input.GetAxis(Horizontal), track.GetBoundaries());
        }

        private void Strafe(float horizontal, (float, float) boundaries)
        {
            if (horizontal == 0) return;

            var velocity = Vector3.right * speed * Time.deltaTime;
            var newPos = Mathf.Sign(horizontal) * velocity + transform.localPosition;
            
            var clampedX = Mathf.Clamp(newPos.x, boundaries.Item1 + 0.5f, boundaries.Item2 - 0.5f);
            
            transform.localPosition = new Vector3(clampedX, newPos.y, newPos.z);
        }
    }
}
