using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] public int CoinsToBeRewarded;

    [SerializeField] Sprite _skin;
    [SerializeField] Player _player;

    private void Start()
    {
        _skin = InventoryManager.Instance._currentSkin;
        if (_skin == null)
        {
            _skin = InventoryManager.Instance._defaultSkin;
        }
        
        _player.GetComponentInChildren<SpriteRenderer>().sprite = _skin;
        

    }
}
