using UnityEngine;

public class SpinTrap : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
