using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float offsetX;
    private float initialPlayerX;
    public float maxCameraX = 173f; // Límite máximo en X para la cámara

    private LevelsManager levelManager;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform != null)
        {
            initialPlayerX = playerTransform.position.x;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float targetX = Mathf.Max(playerTransform.position.x, initialPlayerX) + offsetX;
            // Limitar el valor de targetX al límite máximo
            targetX = Mathf.Min(targetX, maxCameraX);
            transform.position = new Vector3(targetX, 0f, -10f);
        }
    }
}

