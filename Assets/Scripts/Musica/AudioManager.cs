using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio clip------")]
    public AudioClip BackGround;
    public AudioClip Lose;
    public AudioClip Disparo;
    public AudioClip Win;

    private void Start()
    {
        musicSource.clip = BackGround;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && SFXSource != null) SFXSource.PlayOneShot(clip);
    }
}