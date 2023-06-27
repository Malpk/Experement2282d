using UnityEngine;

public class DecalBody : MonoBehaviour
{
    [SerializeField] private Pool _decalPool; 

    public void CreateDecal(Transform projectile)
    {
        var decal = _decalPool.Create();
        decal.transform.position = projectile.position;
        decal.transform.rotation = projectile.rotation;
        decal.transform.parent = transform;
    }
}
