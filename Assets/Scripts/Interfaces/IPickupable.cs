using UnityEngine;

namespace Interfaces
{
    public interface IPickupable
    {
        public GameObject GO { get; }
        public SpringJoint SpringJoint { get; }
        public Rigidbody Rigidbody { get; }

        public void Pickup();
    }
}