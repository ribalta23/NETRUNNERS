using System.Collections;
using UnityEngine;

public class ChangeColorlvl4 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;
    private Color colorParpadeo;
    public float duracionParpadeo = 0.5f;
    public float duracionEspera = 0.2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        // Cambiar el color de parpadeo a B25C5C
        colorParpadeo = new Color(0.698f, 0.361f, 0.361f);
        StartCoroutine(Parpadear());
    }

    IEnumerator Parpadear()
    {
        while (true)
        {
            float tiempoPasado = 0f;
            while (tiempoPasado < duracionParpadeo)
            {
                spriteRenderer.color = Color.Lerp(colorOriginal, colorParpadeo, tiempoPasado / duracionParpadeo);
                tiempoPasado += Time.deltaTime;
                yield return null;
            }
            spriteRenderer.color = colorParpadeo;
            yield return new WaitForSeconds(duracionEspera);

            tiempoPasado = 0f;
            while (tiempoPasado < duracionParpadeo)
            {
                spriteRenderer.color = Color.Lerp(colorParpadeo, colorOriginal, tiempoPasado / duracionParpadeo);
                tiempoPasado += Time.deltaTime;
                yield return null;
            }
            spriteRenderer.color = colorOriginal;
            yield return new WaitForSeconds(duracionEspera);
        }
    }
}
