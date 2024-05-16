using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Color colorOriginal;
    public Color colorCambio = Color.white;
    private Sprite spriteOriginal;
    public Sprite spriteCambio;
    private SpriteRenderer spriteRenderer;
    public Boolean leverActived = true;

    private LevelsManager levelManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        spriteOriginal = spriteRenderer.sprite;
        leverActived = true;

        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");
        levelManager = levelManagerObject.GetComponent<LevelsManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.color = colorCambio;

            if (Input.GetMouseButtonDown(1) && leverActived == true)
            {
                spriteRenderer.sprite = spriteCambio;
                leverActived = false;

                levelManager.objectsDesactivated++;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.color = colorOriginal;
        }
    }
}
