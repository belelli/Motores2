using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] LevelSettings _levelSettings;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CompleteLevel();
    }

    private void CompleteLevel()
    {
        //guardo las monedas ganadas
        int coinsToReward = _levelSettings.CoinsToBeRewarded;
        CoinsManager.Instance.AddCoins(coinsToReward);
        //Actualizar LevelDataManager
        LevelDataManager.Instance.SetCoinsEarned(coinsToReward);
        //cargo la escena de victoria
        GameManager.Instance.WinGame();
    }
}
