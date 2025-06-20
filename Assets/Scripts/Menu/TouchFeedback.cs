using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchFeedback : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float scaleFactor = 0.9f;
    private Vector3 originalScale;

    [Header("Audio")]
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        originalScale = transform.localScale;

       
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
         
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * scaleFactor;

        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
}