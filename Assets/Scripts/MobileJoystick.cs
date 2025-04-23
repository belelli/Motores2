using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;
    [SerializeField] private float handleRange = 1f;

    private Vector2 inputVector = Vector2.zero;
    private bool isActive = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (!isActive) return;

        Vector2 direction = eventData.position - (Vector2)joystickBackground.position;
        inputVector = (direction.magnitude > joystickBackground.sizeDelta.x / 2f)
            ? direction.normalized
            : direction / (joystickBackground.sizeDelta.x / 2f);

        joystickHandle.anchoredPosition = inputVector * joystickBackground.sizeDelta.x / 2f * handleRange;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isActive) return;

        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isActive) return;

        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }

    public void SetActive(bool active)
    {
        isActive = active;
        if (!active)
        {
            inputVector = Vector2.zero;
            joystickHandle.anchoredPosition = Vector2.zero;
        }
    }
}