using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LogicaBotones : MonoBehaviour
{
    [SerializeField] private Transform canvas;

    void Start()
    {
        //CreateMenuButton("Jugar", new Vector2(0, 200));
       // CreateMenuButton("Opciones", new Vector2(0, 0));
        // CreateMenuButton("Salir", new Vector2(0, -200));
    }

    void CreateMenuButton(string buttonText, Vector2 position)
    {
      
            GameObject buttonObj = new GameObject(buttonText + " Button");
            buttonObj.transform.SetParent(canvas.transform);

            RectTransform rect = buttonObj.AddComponent<RectTransform>();
            rect.sizeDelta = new Vector2(200, 80);
            rect.anchoredPosition = position;

            Image image = buttonObj.AddComponent<Image>();
            buttonObj.AddComponent<Button>();

            GameObject textObj = new GameObject("Text");
            textObj.transform.SetParent(buttonObj.transform);

        TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
        text.text = buttonText;
        text.fontSize = 24;
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.black;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
      
    }
}
