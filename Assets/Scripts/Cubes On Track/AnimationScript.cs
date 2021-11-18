using UnityEngine;

namespace Cubes_On_Track
{
    public class AnimationScript : MonoBehaviour
    {
        [SerializeField] private bool isAnimated;
        [SerializeField] private bool isRotating;
        [SerializeField] private bool isFloating;

        [SerializeField] private Vector3 rotationVelocity;

        [SerializeField] private float floatSpeed;
        [SerializeField] private float floatRate;
        
        private float _floatTimer;
        private bool _goingUp = true;

        private void Update()
        {
            if (!isAnimated) return;
            if (isRotating) transform.Rotate(rotationVelocity * Time.deltaTime);

            if (!isFloating) return;
            _floatTimer += Time.deltaTime;
            var moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
            transform.Translate(moveDir);

            switch (_goingUp)
            {
                case true when _floatTimer >= floatRate:
                    _goingUp = false;
                    _floatTimer = 0;
                    floatSpeed = -floatSpeed;
                    break;
                case false when _floatTimer >= floatRate:
                    _goingUp = true;
                    _floatTimer = 0;
                    floatSpeed = +floatSpeed;
                    break;
            }
        }
    }
}