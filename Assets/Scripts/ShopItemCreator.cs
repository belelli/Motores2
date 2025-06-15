using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemCreator : MonoBehaviour
{
    [SerializeField] ShopItemDisplay _itemPrefab;
    [SerializeField] private List<GameObject> _items = new List<GameObject>();
    [SerializeField] private GameObject _contentParent;

    void Start()
    {
        var newItem = Instantiate(_itemPrefab);
        
        _items.Add(newItem.gameObject);
        _items.Add(newItem.gameObject);
        
        foreach (var item in _items)
        {
            Instantiate(_itemPrefab, _contentParent.transform);
        }
    }
}

