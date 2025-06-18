using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
     [SerializeField] TextMeshProUGUI _itemNameText, _itemDescriptionText, _itemCostText;
     [SerializeField] Image _itemIcon;
     [SerializeField] Button _buyButton;
     
     public void Initialize(ShopItemSO itemInfo)
     {
          _itemNameText.text = itemInfo.itemName;
          _itemDescriptionText.text = itemInfo.itemDescription;
          _itemCostText.text = "$ "+itemInfo.itemCost.ToString();
          _itemIcon.sprite = itemInfo.itemIcon;
          _buyButton.onClick.AddListener(itemInfo.BuyItem);
          
     }
}
