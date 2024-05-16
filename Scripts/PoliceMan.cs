using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMan : MonoBehaviour
{
    public float speed;
    public Transform groundController;
    public float distance;
    public List<Sprite> movingSprites;
    public List<Sprite> idleSprites;
    public List<Sprite> shootingSprites;
    private float idleAnimationTime = 0.3f;
    private float moveAnimationTime = 0.1f;
    private float shootAnimationTime = 0.125f;
    private bool moveRight;
    private Rigidbody2D rb;
    private bool rotating;
    private float rotationTimer = 2f;
    private float rotationTimerCounter;
    private SpriteRenderer spriteRenderer;
    public Transform firePoint;
    public float fireDistance;
    public LayerMask playerLayer;
    public bool playerLayerInRange;
    public GameObject enemyBullet;
    public float timeShoot;
    public float timeLastShoot;
    private int currentSpriteIndex;
    private float timer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rotationTimerCounter = rotationTimer;
        timer = 0;
    }

    private void Update()
    {
        playerLayerInRange = Physics2D.Raycast(firePoint.position, transform.right, fireDistance, playerLayer);

        if (playerLayerInRange)
        {
            if (Time.time > timeShoot + timeLastShoot)
            {
                timeLastShoot = Time.time;
                Invoke(nameof(Shoot), timeShoot);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoGround = Physics2D.Raycast(groundController.position, Vector2.down, distance);

        if (!rotating && !playerLayerInRange)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            PlayAnimation(movingSprites, moveAnimationTime);
        }
        else if(rotating)
        {
            rb.velocity = Vector2.zero;
            PlayAnimation(idleSprites, idleAnimationTime);
        }
        else if(playerLayerInRange)
        {
            rb.velocity = Vector2.zero;
            PlayAnimation(shootingSprites, shootAnimationTime);
        }

        if (infoGround == false && !rotating)
        {
            rotating = true;
            rotationTimerCounter = rotationTimer;
        }

        if (rotating)
        {
            rotationTimerCounter -= Time.deltaTime;
            if (rotationTimerCounter <= 0f)
            {
                Rotate();
                rotating = false;
            }
        }
    }

    private void Rotate()
    {
        moveRight = !moveRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * distance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(firePoint.position, firePoint.position + transform.right * fireDistance);
    }
}
