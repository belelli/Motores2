using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("--------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio clip------")]
    public AudioClip BackGround;
    public AudioClip Lose;
    public AudioClip Disparo;
    public AudioClip Win;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource.clip = BackGround;
            musicSource.loop = true;
            musicSource.Play();

            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            musicSource.volume = savedVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public float GetVolume()
    {
        return musicSource.volume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && SFXSource != null)
            SFXSource.PlayOneShot(clip);
    }
}
