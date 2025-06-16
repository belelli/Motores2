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
    public string itemId;

    

    public void BuyItem()
    {
        if (CoinsManager.Instance.CoinQty >= itemCost)
        {
            Debug.Log(itemName + " comprado");
            CoinsManager.Instance.SpendCoins(itemCost);
            InventoryManager.Instance.PurchaseItem(itemId);
            
        }
        else
        {
            Debug.Log("No se pudo comprar");
        }
    }
}
