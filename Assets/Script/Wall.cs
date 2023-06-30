using UnityEngine;

public class Wall : MonoBehaviour, IDamage
{
    [SerializeField] private DecalBody _decal;

    public bool TakeDamage(int damage, Transform hit)
    {
        _decal.CreateDecal(hit);
        return true;
    }
}
