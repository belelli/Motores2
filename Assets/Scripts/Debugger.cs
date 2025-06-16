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
            CoinsManager.Instance.AddCoins(10);
        }
        if (Input.GetKeyDown(KeyCode.B)) 
        { 
            CoinsManager.Instance.SpendCoins(5);
        }
        
        if (Input.GetKeyDown(KeyCode.D)) 
        { 
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs han sido borrados!");
        }
        
        if (Input.GetKeyDown(KeyCode.L)) 
        { 
            //InventoryManager.Instance.load(){}
            Debug.Log("LOG");
            Debug.Log("producto 101 " + InventoryManager.Instance.ProductIsInInventory("101"));
            Debug.Log("producto 102 " + InventoryManager.Instance.ProductIsInInventory("102"));
            
            var s = PlayerPrefs.GetInt("ProductPurchased_101");
            Debug.Log("directop de PP "+s.ToString());
        }
        
    }
}
