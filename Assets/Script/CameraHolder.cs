using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Range(0,1f)]
    [SerializeField] private float _smoothTime = 0.2f;
    [Header("Reference")]
    [SerializeField] private Transform _target;

    private Vector3 _velocity;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position,
            ref _velocity, _smoothTime);
    }
}
