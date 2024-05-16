using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public TextMeshProUGUI tituloText;
    public TextMeshProUGUI autorText;

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(MostrarCreditos());
    }

    IEnumerator MostrarCreditos()
    {
        tituloText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(DesvanecerTexto(tituloText));

        yield return new WaitForSeconds(2f);
        autorText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(DesvanecerTexto(autorText));

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    IEnumerator DesvanecerTexto(TextMeshProUGUI texto)
    {
        Color color = texto.color;
        for (float i = 1f; i >= 0; i -= Time.deltaTime)
        {
            color.a = i;
            texto.color = color;
            yield return null;
        }
        texto.gameObject.SetActive(false);
    }
}
