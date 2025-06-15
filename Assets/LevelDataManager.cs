using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager Instance;
    public int CoinsEarnedInCurrentLevel { get; private set; }= 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCoinsEarned(int qty)
    {
        CoinsEarnedInCurrentLevel = qty;
    }

    public void ResetLevelCoins()
    {
        CoinsEarnedInCurrentLevel = 0;
    }
    
    
}
