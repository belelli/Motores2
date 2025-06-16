using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    [SerializeField]public int CoinQty { get;private set; }

    [SerializeField] private int _defaultCoinQty;
    
    [SerializeField] TextMeshProUGUI _coinQtyText;
    
    
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
        LoadData();
    }

    private void Start()
    {
        UpdateCoinText();
    }


    void LoadData()
    {
        CoinQty = PlayerPrefs.GetInt("CoinQty", _defaultCoinQty);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("CoinQty", CoinQty);
    }

    void UpdateCoinText()
    {
        _coinQtyText.text = "$ "+CoinQty.ToString();
    }

    public void AddCoins(int qty)
    {
        CoinQty += qty;
        SaveData();
        UpdateCoinText();
    }

    public void SpendCoins(int qty)
    {
        CoinQty -= qty;
        SaveData();
        UpdateCoinText();
    }
    
    
    
}
