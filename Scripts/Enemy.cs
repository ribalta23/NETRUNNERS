using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    private LevelsManager levelManager;
    void Start()
    {
        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");
        levelManager = levelManagerObject.GetComponent<LevelsManager>();
    }
    void Update()
    {
        if(life <= 0)
        {
            levelManager.enemiesDefeated++;
            Invoke("destroyEnemy", 0f);
        }
    }

    private void destroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            life = life - 5;
        }
    }
}
