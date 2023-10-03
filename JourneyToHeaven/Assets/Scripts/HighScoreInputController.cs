using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(TMP_InputField))]

// highScoreInput is a child of canvas
public class HighScoreInputController : MonoBehaviour
{
    private HighScoreList highScoreList;
    private string highScoreListJson;
    private GameObject highScoreTable;
    private string path;
    private GameObject placeholder;
    private TMP_Text placeholderTmpText;
    private RectTransform rectTransform;
    private GameObject text;
    private RectTransform textRectTransform;
    private TMP_Text textTmpText;
    private string textTmpTextEmpty;
    private float time;
    private string timeString;
    private GameObject timer;
    private TimerController timerController;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/highScoreList.json";
        highScoreListJson = System.IO.File.ReadAllText(path);
        highScoreList = JsonUtility.FromJson<HighScoreList>(highScoreListJson);
        highScoreTable = GameObject.FindWithTag("HighScoreTable");
        placeholder = transform.Find("Text Area").Find("Placeholder").gameObject;
        placeholderTmpText = placeholder.GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        text = transform.Find("Text Area").Find("Text").gameObject;
        textRectTransform = text.GetComponent<RectTransform>();
        textTmpText = text.GetComponent<TextMeshProUGUI>();
        textTmpTextEmpty = textTmpText.text;
        timer = GameObject.Find("Timer");
        timerController = timer.GetComponent<TimerController>();
        time = timerController.GetTime();
        timeString = timerController.GetTimeString();
        // placeholderTmpText
        placeholderTmpText.enableAutoSizing = true;
        placeholderTmpText.fontSizeMax = 1000f;
        placeholderTmpText.fontSizeMin = 0f;
        placeholderTmpText.text = "New High Score!\nEnter your name...";
        // rectTransform
        rectTransform.anchorMax = new Vector2(0.225f, 0.55f);
        rectTransform.anchorMin = new Vector2(0.075f, 0.45f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
        // textRectTransform
        textRectTransform.anchorMax = new Vector2(1f, 0.8f);
        textRectTransform.anchorMin = new Vector2(0f, 0.2f);
        textRectTransform.offsetMax = new Vector2(0f, 0f);
        textRectTransform.offsetMin = new Vector2(0f, 0f);
        // textTmpText
        textTmpText.alignment = TextAlignmentOptions.Left;
        textTmpText.enableAutoSizing = true;
        textTmpText.fontSizeMax = 1000f;
        textTmpText.fontSizeMin = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (textTmpText.text != textTmpTextEmpty && Input.GetKeyUp("return"))
        {
            SaveHighScore(textTmpText.text);
            Destroy(gameObject);
        }
    }

    void SaveHighScore(string name)
    {
        HighScore highScore = new HighScore(name, time, timeString);
        if (highScoreList.list.Count == 0)
        {
            highScoreList.list.Add(highScore);
        }
        else
        {
            if (time >= highScoreList.list[highScoreList.list.Count - 1].time)
            {
                highScoreList.list.Add(highScore);
            }
            else
            {
                for (int i = 0; i < highScoreList.list.Count; i++)
                {
                    if (time < highScoreList.list[i].time)
                    {
                        highScoreList.list.Insert(i, highScore);
                        break;
                    }
                }
            }
            if (highScoreList.list.Count > 10)
            {
                highScoreList.list.RemoveAt(10);
            }
        }
        highScoreListJson = JsonUtility.ToJson(highScoreList);
        System.IO.File.WriteAllText(path, highScoreListJson);
    }
}