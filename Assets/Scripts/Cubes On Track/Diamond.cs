using Interfaces;
using UI.Score;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cubes_On_Track
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Diamond : MonoBehaviour
    {
        [SerializeField] private int cost = 10;
        [SerializeField] private AudioSource pickupSound;
    
        private Animator _animator;

        private bool _added;
        private static readonly int PickedUp = Animator.StringToHash("pickedUp");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_added || other.GetComponent<IPickupable>() == null) return;
        
            ScoreModel.Instance.Add(cost);
            pickupSound.pitch = Random.Range(0.93f, 1.07f);
            pickupSound.Play();
            _animator.SetBool(PickedUp, true);
            Destroy(gameObject, 2f);

            _added = true;
        }
    }
}
