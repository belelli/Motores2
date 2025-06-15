using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelReward : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _rewardtext;

    private void Awake()
    {
        int reward = LevelDataManager.Instance.CoinsEarnedInCurrentLevel;
        _rewardtext.text = "Ganaste " + reward + "monedas";
    }
}


