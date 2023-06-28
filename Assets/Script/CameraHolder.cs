using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Range(0,1f)]
    [SerializeField] private float _smoothTime = 0.2f;
    [SerializeField] private Vector2 _upBorder;
    [SerializeField] private Vector2 _downBorder;
    [Header("Reference")]
    [SerializeField] private Transform _target;

    private Vector3 _velocity;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector2(_upBorder.x, _downBorder.y), _upBorder);
        Gizmos.DrawLine(new Vector2(_downBorder.x, _upBorder.y), _downBorder);
    }

    private void LateUpdate()
    {
        var position = Vector3.SmoothDamp(transform.position, _target.position,
            ref _velocity, _smoothTime);
        position.x = Mathf.Clamp(position.x, _downBorder.x, _upBorder.x);
        position.y = Mathf.Clamp(position.y, _downBorder.y, _upBorder.y);
        transform.position = position;
    }
}
