using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform fireController;
    public float distance;
    public LayerMask player;
    public bool playerInRange;
    public GameObject bullet;
    public float timeShoot;
    public float lastShoot;
    public float timeInShot;

    public List<Sprite> idleSprites;
    public List<Sprite> shootSprites;
    private float idleAnimationTime = 0.3f;
    private float shotAnimationTime = 0.1f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float timer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        playerInRange = Physics2D.Raycast(fireController.position, -transform.right, distance, player);
        if (playerInRange)
        {
            if (Time.time > timeShoot + lastShoot)
            {
                lastShoot = Time.time;
                Invoke(nameof(Shoot), timeInShot);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!playerInRange)
        {
            PlayAnimation(idleSprites, idleAnimationTime);
        }
        else
        {
            PlayAnimation(shootSprites, shotAnimationTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(fireController.position, fireController.position + -transform.right * distance);
    }

    private void Shoot()
    {
        Instantiate(bullet, fireController.position, fireController.rotation);
    }

    private void PlayAnimation(List<Sprite> sprites, float animationTime)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Count;
            spriteRenderer.sprite = sprites[currentSpriteIndex];
            timer = animationTime;
        }
    }
}
