using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [Header("Reference")]
    [SerializeField] private Wallet _wallet;

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        var data = new PlayerData();
        data.Money = _wallet.Money;
        PlayerPrefs.SetString(_saveKey, JsonUtility.ToJson(data));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            var data = JsonUtility.FromJson<PlayerData>(
                PlayerPrefs.GetString(_saveKey));
            _wallet.SetMoney(data.Money);
        }
    }
}
