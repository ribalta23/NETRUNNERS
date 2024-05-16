using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;
    public float animationSpeed = 0.1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Animate", 0, animationSpeed);
    }

    private void Animate()
    {
        currentIndex = (currentIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentIndex];
    }
}
