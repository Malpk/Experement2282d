using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioClip _hit;
    [Header("Reference")]
    [SerializeField] private AudioSource _source;

    public void Hit()
    {
        _source.PlayOneShot(_hit);
    }
}
