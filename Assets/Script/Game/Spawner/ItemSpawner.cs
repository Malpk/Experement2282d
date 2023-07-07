using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnProbility;
    [SerializeField] private ItemSpawnSlot[] _slots;

    public void Spawn(Vector2 position)
    {
        var probility = Random.Range(0f, 1f);
        if (probility <= _spawnProbility)
        {
            var item = _slots[Random.Range(0, _slots.Length)].Create();
            item.transform.position = position;
            item.transform.parent = transform;
        }
    }
}
