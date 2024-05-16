using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private LevelsManager levelManager;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> animatedSprites;
    public float timeInteractionMax = 3.0f;
    private bool playerInArea;
    private bool click;
    private float timeInteraction;
    private bool interactionEnded;

    void Start()
    {
        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");
        levelManager = levelManagerObject.GetComponent<LevelsManager>();
    }

    void Update()
    {
        if (playerInArea && Input.GetMouseButton(1) && !interactionEnded)
        {
            click = true;
            timeInteraction += Time.deltaTime;

            int indiceSprite = Mathf.FloorToInt((timeInteraction / timeInteractionMax) * animatedSprites.Count);
            indiceSprite = Mathf.Clamp(indiceSprite, 0, animatedSprites.Count - 1);

            spriteRenderer.sprite = animatedSprites[indiceSprite];

            if (indiceSprite == animatedSprites.Count - 1)
            {
                interactionEnded = true;
                if(levelManager.gameManager.currentLevel == 3)
                {
                    levelManager.dataHeisted++;
                } else if(levelManager.gameManager.currentLevel == 4)
                {
                    levelManager.virusInjected++;
                }
            }
        }
        else
        {
            click = false;
            timeInteraction = 0f;
        }

        if (click)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }
}
