using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance;
    [SerializeField]private int _coinQty;

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
        _coinQty = PlayerPrefs.GetInt("CoinQty", _defaultCoinQty);
    }

    public void SaveData(int qty)
    {
        PlayerPrefs.SetInt("CoinQty", _coinQty+qty);
    }

    void UpdateCoinText()
    {
        _coinQtyText.text = "$ "+_coinQty.ToString();
    }
}
