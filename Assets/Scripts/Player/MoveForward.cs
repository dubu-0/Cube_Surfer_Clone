using System;
using UnityEngine;

namespace Player
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        public void Stop()
        {
            speed = 0;
        }
    }
}
