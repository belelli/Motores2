using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SFXSource.PlayOneShot(clip);

    }
}

