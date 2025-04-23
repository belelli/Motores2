using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OneTouchController : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // Detecta qu� bot�n se ha tocado
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (clickedObject != null)
        {
            Button button = clickedObject.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
}