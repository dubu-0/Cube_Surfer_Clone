using UnityEngine;

namespace Player
{
    public class PlayerStrafe : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Track.Track track;
        
        private float _initialMousePosX;
        private float _deltaX;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _initialMousePosX = Input.mousePosition.x;
            
            Strafe(track.GetBoundaries());
        }

        private void Strafe((float, float) boundaries)
        {
            if (!Input.GetMouseButton(0)) return;

            _deltaX = Input.mousePosition.x - _initialMousePosX;

            var strafeStep = speed * _deltaX * Time.deltaTime;
            var currentPos = transform.localPosition;
            currentPos.x = Mathf.Clamp(currentPos.x + strafeStep, boundaries.Item1 + 0.5f, boundaries.Item2 - 0.5f);
            transform.localPosition = currentPos;
            
            _initialMousePosX = Input.mousePosition.x;
        }
    }
}
