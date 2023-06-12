using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private float _spread;
    [Header("References")]
    [SerializeField] private Transform[] _points;

    public int CountBullet => _points.Length;


}
