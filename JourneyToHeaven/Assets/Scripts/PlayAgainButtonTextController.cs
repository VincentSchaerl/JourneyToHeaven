using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(TextMeshProUGUI))]

public class PlayAgainButtonTextController : MonoBehaviour
{
    private RectTransform rectTransform;
    private TMP_Text tmpText;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        tmpText = GetComponent<TextMeshProUGUI>();
        // rectTransform
        rectTransform.anchorMax = new Vector2(1f, 0.8f);
        rectTransform.anchorMin = new Vector2(0f, 0.2f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
        // tmpText
        tmpText.enableAutoSizing = true;
        tmpText.fontSizeMax = 1000f;
        tmpText.fontSizeMin = 0f;
        tmpText.text = "Play Again";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
