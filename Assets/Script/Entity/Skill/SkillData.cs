using UnityEngine;

[CreateAssetMenu(menuName = "Player/SkillData")]
public class SkillData : ScriptableObject
{
    [SerializeField] private int _key;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private string _desciption;
    [SerializeField] private Sprite _icon;

    public int SkillKey => _key;
    public int Price => _price;
    public string Name => _name;
    public string Description => _desciption;
    public Sprite Icon => _icon;

}
