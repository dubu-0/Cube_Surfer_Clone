using System;
using UnityEngine;

public class PlayerStrafe : MonoBehaviour
{
    [SerializeField] private float speed = 15;

    private const string Horizontal = nameof(Horizontal);

    private void LateUpdate()
    {
        Strafe(Input.GetAxis(Horizontal));
    }

    private void Strafe(float direction)
    {
        var newPos = new Vector3(speed * Time.deltaTime, 0, 0);

        if (direction != 0)
            transform.localPosition += Mathf.Sign(direction) * newPos;
    }
}
