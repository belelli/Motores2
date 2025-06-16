using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemCreator : MonoBehaviour
{
    [SerializeField] ShopItemDisplay _itemPrefab;
    [SerializeField] private List<ShopItemSO> _items = new List<ShopItemSO>();
    [SerializeField] private GameObject _contentParent;

    void Start()
    {
        foreach (var item in _items)
        {
            var newItem = Instantiate(_itemPrefab, _contentParent.transform);
            newItem.Initialize(item);
        }
    }
}

