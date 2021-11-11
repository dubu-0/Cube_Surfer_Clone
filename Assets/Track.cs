using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Track : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _leftBoundary;
    private float _rightBoundary;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _leftBoundary = _meshRenderer.bounds.min.x;
        _rightBoundary = _meshRenderer.bounds.max.x;
    }

    public (float, float) GetBoundaries() => (_leftBoundary, _rightBoundary);
}
