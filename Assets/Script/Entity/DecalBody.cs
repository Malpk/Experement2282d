using UnityEngine;

public class DecalBody : MonoBehaviour
{
    [SerializeField] private Pool _decalPool; 

    public void CreateDecal(Vector2 hit)
    {
        var decal = _decalPool.Create();
        decal.transform.position = hit;
        decal.transform.parent = transform;
    }
}
