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
        private bool _parentedToOther;
        
        public SpringJoint SpringJoint { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GameObject GO { get; private set; }

        private void Start()
        {
            SpringJoint = GetComponent<SpringJoint>();
            Rigidbody = GetComponent<Rigidbody>();
            GO = gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((other.gameObject.GetComponent<FinishPlatform>() == null) ==
                (other.gameObject.GetComponent<Ladder>() == null)) return;

            _parentedToOther = true;
        }

        private void OnTransformParentChanged()
        {
            if (_parentedToOther || transform.parent == pickups.transform) return;

            _parentedToOther = true;
            
            Destroy(this);
            Destroy(SpringJoint);
            Destroy(Rigidbody);
            
            pickups.UpdatePickups();
            Destroy(gameObject, 3f);
        }
        
        public void Pickup()
        {
            if (_pickedUp) return;
            pickups.Add(this);
            _pickedUp = true;
        }
    }
}