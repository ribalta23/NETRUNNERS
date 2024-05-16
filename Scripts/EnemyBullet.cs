using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;


    public List<Sprite> bulletSprites;
    public float bulletAnimationTime = 0.1f;
    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentSpriteIndex;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Time.deltaTime * bulletSpeed * Vector2.right);
        timer += Time.deltaTime;
        if (timer >= bulletAnimationTime)
        {
            timer -= bulletAnimationTime;
            currentSpriteIndex = (currentSpriteIndex + 1) % bulletSprites.Count;
            spriteRenderer.sprite = bulletSprites[currentSpriteIndex];
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
