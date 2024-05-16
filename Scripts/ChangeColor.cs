using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colores = new Color[]
    {
        Color.red,
        new Color(1.0f, 0.5f, 0.0f),
        Color.yellow,
        new Color(0.5f, 1.0f, 0.0f),
        Color.green,
        new Color(0.0f, 0.5f, 1.0f),
        Color.blue,
        new Color(0.5f, 0.0f, 1.0f),
        Color.magenta,
        new Color(1.0f, 0.0f, 0.5f),
        Color.cyan,
        new Color(0.0f, 1.0f, 1.0f),
        new Color(0.5f, 0.5f, 0.5f),
        new Color(1.0f, 1.0f, 1.0f)
    };
    public float tiempoPorColor = 3.0f;
    public float velocidadTransicion = 0.2f;
    private int indexColorActual = 0;
    private SpriteRenderer spriteRenderer;
    private Color colorActual;
    private Color colorSiguiente;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorActual = colores[0];
        colorSiguiente = colores[1];
        InvokeRepeating("CambiarColor", 0, tiempoPorColor);
    }

    void CambiarColor()
    {
        indexColorActual = (indexColorActual + 1) % colores.Length;
        colorSiguiente = colores[indexColorActual];
    }

    void Update()
    {
        colorActual = Color.Lerp(colorActual, colorSiguiente, velocidadTransicion * Time.deltaTime);
        spriteRenderer.color = colorActual;
    }
}
