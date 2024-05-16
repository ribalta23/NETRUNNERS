using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    private LevelsManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool hitByBullet;

    void Start()
    {
        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");
        levelManager = levelManagerObject.GetComponent<LevelsManager>();

        // Obtener el componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Guardar el color original del SpriteRenderer
        originalColor = spriteRenderer.color;
    }
    void Update()
    {
        if (life <= 0)
        {
            levelManager.playerAlive = false;
            Invoke("playerDead", 1.5f);
        }

        levelManager.playerLife = life;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Reducir la vida del jugador
            life -= 10;

            // Cambiar el color del SpriteRenderer a rojo
            spriteRenderer.color = Color.red;

            // Establecer hitByBullet a true para indicar que fue golpeado por una bala
            hitByBullet = true;

            // Restaurar el color original después de 1 segundo
            Invoke("RestoreColor", 0.5f);
        }
        if (collision.gameObject.CompareTag("Finish") && levelManager.firstObjective == true)
        {
            levelManager.final = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            levelManager.playerAlive = false;
            Destroy(gameObject);
        }
    }

    private void playerDead()
    {
        Destroy(gameObject);
    }

    private void RestoreColor()
    {
        // Restaurar el color original del SpriteRenderer si fue golpeado por una bala
        if (hitByBullet)
        {
            spriteRenderer.color = originalColor;
            hitByBullet = false;
        }
    }
}
