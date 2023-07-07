using UnityEngine;
using System.Collections.Generic;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [Header("Reference")]
    [SerializeField] private Shop _shop;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GunHolder _gunHolder;
    [SerializeField] private DataHolder _data;

    private PlayerData _loadData;

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        var data = new PlayerData();
        data.Money = _wallet.Money;
        data.GunHolderData = _gunHolder.Save();
        data.ShopData = _shop ? _shop.Save() : _loadData.ShopData;
        PlayerPrefs.SetString(_saveKey, JsonUtility.ToJson(data));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            _loadData = JsonUtility.FromJson<PlayerData>(
                PlayerPrefs.GetString(_saveKey));
            _wallet.SetMoney(_loadData.Money);
            LoadGun(_loadData.GunHolderData);
            LoadShop(_loadData.ShopData);
        }
    }

    private void LoadGun(string gunHolder)
    {
        if (gunHolder != null)
        {
            var data = JsonUtility.FromJson<GunHolderData>(gunHolder);
            var guns = new Gun[data.ContainGuns.Length];
            for (int i = 0; i < data.ContainGuns.Length; i++)
            {
                if (data.ContainGuns[i] != -1)
                {
                    var item = _data.GetItem(data.ContainGuns[i]);
                    guns[i] = item.GetComponent<Gun>();
                }
                else
                {
                    guns[i] = null;
                }
            }
            _gunHolder.Load(guns, data.ChooseGun);
        }
    }

    private void LoadShop(string data)
    {
        if (_shop && data != null)
        {
            var shopData = JsonUtility.FromJson<ShopData>(data);
            var buyList = new List<DataItem>();
            foreach (var item in shopData.BuyList)
            {
                buyList.Add(_data.GetItem(item));
            }
            _shop.Load(buyList);
        }
    }

}
