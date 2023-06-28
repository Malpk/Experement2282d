using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private EnemyBrain _brain;
    [SerializeField] private EnemyHealth _health;

    public void Reset()
    {
        _health.Reset();
    }

    private void Start()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        _brain.UpdateState();
    }
}
