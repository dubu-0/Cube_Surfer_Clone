using UnityEngine;

namespace Interfaces
{
    public interface IPickupable
    {
        public GameObject GO { get; }

        public void Pickup();
    }
}