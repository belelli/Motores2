using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemCost;

    public void BuyItem()
    {
        if (CoinManager.Instance.CoinQty >= itemCost)
        {
            Debug.Log(itemName + " comprado");
            CoinManager.Instance.SpendCoins(itemCost);
        }
        else
        {
            Debug.Log("No se pudo comprar");
        }
    }
}
