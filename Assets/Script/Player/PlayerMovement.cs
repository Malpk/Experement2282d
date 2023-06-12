using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [Header("Reference")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidBody;

    public void Move(float x, float y)
    {
        var move = new Vector2(x, y) * _speedMovement * Time.fixedDeltaTime;
        _animator.SetBool("move", move != Vector2.zero);
        _rigidBody.MovePosition(_rigidBody.position + move);
    }

}
