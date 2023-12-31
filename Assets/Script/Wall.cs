using UnityEngine;

public class Wall : MonoBehaviour, IDamage
{
    [SerializeField] private DecalBody _decal;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioSource _source;

    public bool TakeDamage(int damage, Vector2 hit = default, Vector2 hitDirection = default)
    {
        _decal.CreateDecal(hit);
        if (_source)
            _source.PlayOneShot(_hit);
        return true;
    }
}
