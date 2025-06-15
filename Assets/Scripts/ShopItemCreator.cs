using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemCreator : MonoBehaviour
{
    [SerializeField] ShopItemDisplay _itemPrefab;
    [SerializeField] private List<ShopItemDisplay> _items = new List<ShopItemDisplay>();
    [SerializeField] private GameObject _contentParent;

    void Start()
    {
        var newItem = Instantiate(_itemPrefab);
        
        _items.Add(newItem);
        _items.Add(newItem);
        
        foreach (var item in _items)
        {
            Instantiate(_itemPrefab, _contentParent.transform);
        }
    }
}

