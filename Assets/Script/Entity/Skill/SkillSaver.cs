using UnityEngine;

public class SkillSaver : MonoBehaviour
{
    [SerializeField] private SkillTreeUI _bodyTree;

    public string Save()
    {
        var skillData = new PlayerSkillData();
        skillData.Body = _bodyTree.Save();
        return JsonUtility.ToJson(skillData);
    }

    public void Load(string data)
    {
        var skillData = JsonUtility.FromJson<PlayerSkillData>(data);
        _bodyTree.Load(skillData.Body);
    }
}
