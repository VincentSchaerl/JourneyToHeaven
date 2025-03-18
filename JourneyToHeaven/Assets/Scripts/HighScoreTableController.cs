using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]

[Serializable]
public class HighScore
{
    public string name;
    public float time;
    public string timeText;

    public HighScore(string _name, float _time, string _timeText)
    {
        name = _name;
        time = _time;
        timeText = _timeText;
    }
}

[Serializable]
public class HighScoreList
{
    public List<HighScore> list;

    public HighScoreList()
    {
        list = new List<HighScore>();
    }

    public HighScoreList(List<HighScore> _list)
    {
        list = _list;
    }
}

// highScoreTable is a child of canvas
public class HighScoreTableController : MonoBehaviour
{
    private GameObject canvas;
    [SerializeField]
    private GameObject highScoreInputPrefab;
    private HighScoreList highScoreList;
    private string highScoreListJson;
    [SerializeField]
    private GameObject highScoreTableHeaderPrefab;
    [SerializeField]
    private GameObject highScoreTableNamesPrefab;
    [SerializeField]
    private GameObject highScoreTableTimesPrefab;
    private string path;
    private RectTransform rectTransform;
    private float time;
    private GameObject timer;
    private TimerController timerController;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        path = Application.persistentDataPath + "/highScoreList.json";
        rectTransform = GetComponent<RectTransform>();
        timer = GameObject.Find("Timer");
        timerController = timer.GetComponent<TimerController>();
        time = timerController.GetTime();
        // gameObject.tag
        gameObject.tag = "HighScoreTable";
        // if not existent, create highScoreLista and, if necessary, instantiate highScoreInput
        if (System.IO.File.Exists(path))
        {
            highScoreListJson = System.IO.File.ReadAllText(path);
            highScoreList = JsonUtility.FromJson<HighScoreList>(highScoreListJson);
            if (highScoreList.list.Count < 10 || (highScoreList.list.Count != 0 && time < highScoreList.list[highScoreList.list.Count - 1].time))
            {
                GameObject highScoreInput = Instantiate(highScoreInputPrefab, canvas.transform) as GameObject;
            }
        }
        else
        {
            highScoreList = new HighScoreList();
            highScoreListJson = JsonUtility.ToJson(highScoreList);
            System.IO.File.WriteAllText(path, highScoreListJson);
            GameObject highScoreInput = Instantiate(highScoreInputPrefab, canvas.transform) as GameObject;
        }
        // rectTransform
        rectTransform.anchorMax = new Vector2(0.925f, 0.75f);
        rectTransform.anchorMin = new Vector2(0.775f, 0.25f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
        // print high score table
        GameObject highScoreTableHeader = Instantiate(highScoreTableHeaderPrefab, transform) as GameObject;
        GameObject highScoreTableNames = Instantiate(highScoreTableNamesPrefab, transform) as GameObject;
        GameObject highScoreTableTimes = Instantiate(highScoreTableTimesPrefab, transform) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
}