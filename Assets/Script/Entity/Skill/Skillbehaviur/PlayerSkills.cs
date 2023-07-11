using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkills : MonoBehaviour
{
    protected List<int> keys = new List<int>();

    public void AddSkill(int key)
    {
        if (!keys.Contains(key))
        {
            keys.Add(key);
            UpdateSkills(key, true);
        }
    }

    public void RemoveSkill(int key)
    {
        UpdateSkills(key, false);
        keys.Remove(key);
    }

    protected abstract void UpdateSkills(int key, bool mode);
}
