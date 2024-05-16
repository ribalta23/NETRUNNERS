using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepMove : MonoBehaviour
{
    public List<Sprite> idleSprites;
    public List<Sprite> moveSprites;
    public List<Sprite> jumpSprites;
    public List<Sprite> shootSprites;
    public float idleAnimationTime = 0.2f;
    public float moveAnimationTime = 0.1f;
    public float jumpAnimationTime = 0.1f;
    public float shootAnimationTime = 0.1f;
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public float shootDelay = 0.5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentSpriteIndex;
    private bool isGrounded;
    private bool isJumping;
    private bool canShoot = true;

    public int life;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0f;
        currentSpriteIndex = 0;
        life = 100;
}

    void Update()
    {
        timer += Time.deltaTime;

        float move = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded)
        {
            if (move != 0)
            {
                transform.Translate(move * moveSpeed * Time.deltaTime, 0, 0);
                if (timer >= moveAnimationTime)
                {
                    ChangeSprite(moveSprites, moveAnimationTime);
                }
                if (move > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                if (timer >= idleAnimationTime)
                {
                    ChangeSprite(idleSprites, idleAnimationTime);
                }
            }
        }
        else
        {
            if (move != 0)
            {
                transform.Translate(move * moveSpeed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            isJumping = true;
            StartCoroutine(PlayJumpAnimation());
        }

        if (isGrounded && isJumping)
        {
            isJumping = false;
            spriteRenderer.sprite = jumpSprites[jumpSprites.Count - 1];
        }
        if (Input.GetButtonDown("Fire1") && canShoot && !isJumping && move == 0)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator PlayJumpAnimation()
    {
        foreach (Sprite jumpSprite in jumpSprites)
        {
            spriteRenderer.sprite = jumpSprite;
            yield return new WaitForSeconds(jumpAnimationTime / jumpSprites.Count);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().SetDirection(transform.localScale.x);
        foreach (Sprite shootSprite in shootSprites)
        {
            spriteRenderer.sprite = shootSprite;
            yield return new WaitForSeconds(shootAnimationTime / shootSprites.Count);
        }
        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    void ChangeSprite(List<Sprite> sprites, float animationTime)
    {
        timer -= animationTime;
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Count;
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }
}
