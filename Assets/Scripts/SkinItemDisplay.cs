using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinItemDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _itemNameText, _itemDescriptionText; //_itemCostText;
    [SerializeField] Image _itemIcon;
    [SerializeField] Button _equipButton;
    ShopItemSO _currentShopItem;

    public Action<SkinItemDisplay> OnSkinSelected;

    public void Initialize(ShopItemSO itemInfo)
    {
        _currentShopItem = itemInfo;
        _itemNameText.text = itemInfo.itemName;
        _itemDescriptionText.text = itemInfo.itemDescription;
        //_itemCostText.text = "$ " + itemInfo.itemCost.ToString();
        _itemIcon.sprite = itemInfo.itemIcon;
        _equipButton.onClick.AddListener(SelectSkinMiddle);

    }

    void SelectSkinMiddle()
    {
        //_currentShopItem.BuyItem();
        InventoryManager.Instance.EquipSkin(_itemIcon.sprite);
        OnSkinSelected?.Invoke(this);
    }
}
