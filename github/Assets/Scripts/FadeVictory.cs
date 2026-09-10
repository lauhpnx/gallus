using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeVictory : MonoBehaviour
{
    public Image fadeImage;
    public float velocidadeFade = 0.8f;
    public string vitoria = "vitória";

    public void IrParaVitoria()
    {
        StartCoroutine(FazerFade());
    }
    IEnumerator FazerFade()
    {
        Color cor = fadeImage.color;

        while (cor.a < 1f)
        {
            cor.a += velocidadeFade * Time.unscaledDeltaTime;

            if (cor.a > 1f)
            {
                cor.a = 1f;
            }

            fadeImage.color = cor;

            yield return null;
        }

        Time.timeScale = 1f;

        SceneManager.LoadScene(vitoria);
    }
}