using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [Header("Reference")]
    [SerializeField] private BodySkillSet _skill;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidBody;

    private float SpeedMovement => _speedMovement + _skill.SpeedMovement;

    public void Move(float x, float y)
    {
        var move = new Vector2(x, y) * SpeedMovement * Time.fixedDeltaTime;
        _rigidBody.isKinematic = move == Vector2.zero;
        _animator.SetBool("move", move != Vector2.zero);
        _rigidBody.MovePosition(_rigidBody.position + move);
    }

}
