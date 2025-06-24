using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FallDeathZone : MonoBehaviour
{
    AudioManager audioManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
           
            if (GameManager.Instance != null)
            {

                AudioManager.Instance.PlaySFX(AudioManager.Instance.Lose);
                GameManager.Instance.PlayerFailed();
            }
        }
    }
}
