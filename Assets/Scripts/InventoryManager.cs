using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    private const string PURCHASE_KEY_PREFIX = "ProductPurchased_";
    public static InventoryManager Instance;
    public Sprite _currentSkin;
    public Sprite _defaultSkin;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PurchaseItem(string id)
    {
        string key = PURCHASE_KEY_PREFIX + id;
        Debug.Log("el id es "+id);
        Debug.Log("La string Key es "+key);
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }

    public bool ProductIsInInventory(string id)
    {
        string key = PURCHASE_KEY_PREFIX + id;
        return PlayerPrefs.GetInt(key) == 1;
    }

    internal void EquipSkin(Sprite skin)
    {
        _currentSkin = skin;
    }
}
