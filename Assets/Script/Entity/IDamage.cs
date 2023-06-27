using UnityEngine;

public interface IDamage
{
    public void TakeDamage(int damage, Transform hit);
    public void Kill();
}
