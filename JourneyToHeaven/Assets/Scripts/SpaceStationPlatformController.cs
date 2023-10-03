using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]

public class SpaceStationPlatformController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private const float xSize = 20f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sortingLayer
        spriteRenderer.sortingLayerName = "SpaceStationPlatform";
        // transform.localScale
        transform.localScale = new Vector3(1f, 1f, 1f);
        float scale = xSize / spriteRenderer.bounds.size.x;
        transform.localScale = new Vector3(scale, scale, 1f);
        // transform.position
        transform.position = new Vector3(0f, 300f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}