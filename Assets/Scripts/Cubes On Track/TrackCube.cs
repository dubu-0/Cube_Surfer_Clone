using System;
using Interfaces;
using Player;
using UnityEngine;

namespace Cubes_On_Track
{
    [RequireComponent(typeof(SpringJoint))]
    [RequireComponent(typeof(Rigidbody))]
    public class TrackCube : MonoBehaviour, IPickupable
    {
        [SerializeField] private PlayerPickups pickups;

        private bool _pickedUp;
        private bool _parentedToWall;
        
        public SpringJoint SpringJoint { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GameObject GO { get; private set; }

        private void Start()
        {
            SpringJoint = GetComponent<SpringJoint>();
            Rigidbody = GetComponent<Rigidbody>();
            GO = gameObject;
        }

        public void Pickup()
        {
            if (_pickedUp) return;
            pickups.Add(this);
            _pickedUp = true;
        }

        private void OnTransformParentChanged()
        {
            if (_parentedToWall || transform.parent == pickups.transform) return;

            _parentedToWall = true;
            pickups.Remove();
            Destroy(gameObject, 3f);
        }
    }
}