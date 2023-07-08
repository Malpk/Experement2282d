using UnityEngine;

public class GunSound : MonoBehaviour
{
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _reload;
    [SerializeField] private AudioClip _emptyMagazine;
    [Header("Reference")]
    [SerializeField] private AudioSource _source;

    public void Shoot()
    {
        _source.PlayOneShot(_shoot);
    }

    public void Reload()
    {
        _source.PlayOneShot(_reload);
    }

    public void EmptyMagazine()
    {
        _source.PlayOneShot(_emptyMagazine);
    }

}
