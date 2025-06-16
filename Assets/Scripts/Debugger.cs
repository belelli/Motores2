using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CoinManager.Instance.AddCoins(10);
        }
        if (Input.GetKeyDown(KeyCode.B)) 
        { 
            CoinManager.Instance.SpendCoins(5);
        }
    }
}
