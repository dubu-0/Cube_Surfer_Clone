using System;
using UnityEngine;

public class PlayerStrafe : MonoBehaviour
{
    [SerializeField] private float speed = 15;
    [SerializeField] private Track track;

    private const string Horizontal = nameof(Horizontal);

    private void LateUpdate()
    {
        Strafe(Input.GetAxis(Horizontal), track.GetBoundaries());
    }

    private void Strafe(float direction, (float, float) boundaries)
    {
        if (direction == 0) return;
        
        var step = new Vector3(speed * Time.deltaTime, 0, 0);
        var newPos = Mathf.Sign(direction) * step + transform.localPosition;
        var clampedX = Mathf.Clamp(newPos.x, boundaries.Item1 + 0.5f, boundaries.Item2 - 0.5f);
        transform.localPosition = new Vector3(clampedX, newPos.y, newPos.z);
    }
}
