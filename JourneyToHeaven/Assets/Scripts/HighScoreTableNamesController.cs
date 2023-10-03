using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(TextMeshProUGUI))]

// highScoreTableNames is a child of highScoreTable
public class HighScoreTableNamesController : MonoBehaviour
{
    private HighScoreList highScoreList;
    private string highScoreListJson;
    private string path;
    private RectTransform rectTransform;
    private TMP_Text tmpText;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/highScoreList.json";
        rectTransform = GetComponent<RectTransform>();
        tmpText = GetComponent<TextMeshProUGUI>();
        // rectTransform
        rectTransform.anchorMax = new Vector2(1f, 0.8f);
        rectTransform.anchorMin = new Vector2(0.5f, 0f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
        // tmpText
        tmpText.alignment = TextAlignmentOptions.Left;
        tmpText.color = new Color32(0, 0, 0, 255);
        tmpText.enableAutoSizing = true;
        tmpText.fontSizeMax = 1000f;
        tmpText.fontSizeMin = 0f;
        tmpText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        highScoreListJson = System.IO.File.ReadAllText(path);
        highScoreList = JsonUtility.FromJson<HighScoreList>(highScoreListJson);
        if (highScoreList.list.Count > 0)
        {
            int numberOfEntries = highScoreList.list.Count;
            float anchorMinY = rectTransform.anchorMax.y - 0.08f * numberOfEntries;
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, anchorMinY);
            string highScoreTableNamesText = "";
            for (int i = 0; i < numberOfEntries; i++)
            {
                highScoreTableNamesText += highScoreList.list[i].name + "\n";
            }
            tmpText.text = highScoreTableNamesText;
        }
    }
}