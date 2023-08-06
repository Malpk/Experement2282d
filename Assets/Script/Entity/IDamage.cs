using UnityEngine;

public interface IDamage
{
    public bool TakeDamage(int damage, Vector2 hit = default, Vector2 hitDirection = default);
}
