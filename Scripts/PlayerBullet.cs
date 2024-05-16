using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public List<Sprite> bulletSprites;
    public float bulletAnimationTime = 0.1f;
    public float bulletSpeed = 10f;
    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentSpriteIndex;
    private float direction;
    public void SetDirection(float direction)
    {
        this.direction = direction;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0f;
        currentSpriteIndex = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(direction, 0) * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
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
