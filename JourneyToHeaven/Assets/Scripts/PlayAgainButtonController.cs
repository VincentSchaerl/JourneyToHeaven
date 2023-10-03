using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(Image))]

public class PlayAgainButtonController : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private PlayerController playerController;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        rectTransform = GetComponent<RectTransform>();
        // button
        ColorBlock colorBlock = button.colors;
        colorBlock.highlightedColor = new Color(0.9f, 0.9f, 0.9f, 1f);
        button.colors = colorBlock;
        // rectTransform
        rectTransform.anchorMax = new Vector2(0.6f, 0.4f);
        rectTransform.anchorMin = new Vector2(0.4f, 0.3f);
        rectTransform.offsetMax = new Vector2(0f, 0f);
        rectTransform.offsetMin = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}