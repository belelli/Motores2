using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinItemCreator : MonoBehaviour
{

    [SerializeField] SkinItemDisplay _itemPrefab;
    [SerializeField] private List<ShopItemSO> _items = new List<ShopItemSO>();
    [SerializeField] private GameObject _contentParent;

    void Start()
    {
        UpdateUI();

    }

    private void UpdateUI()
    {
        foreach (var item in _items)
        {
            if (!InventoryManager.Instance.ProductIsInInventory(item.itemId)) { continue; }
            var newItem = Instantiate(_itemPrefab, _contentParent.transform);
            newItem.Initialize(item);
            newItem.OnSkinSelected += OnSkinDisplaySelected;
        }
    }

    void OnSkinDisplaySelected(SkinItemDisplay item) 
    {
        //Destroy(item.gameObject);
    }
}
