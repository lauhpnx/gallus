using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ade : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadePanel;
    public float velocidadeFade = 0.8f;
    public string vitoria = "vitoria";

    public void Start()
    {
        // Inicia o fade para transparente no início do jogo
        StartCoroutine(FazerFade());
    }
    public void IrParaVitoria()
    {
        StartCoroutine(FazerFade());
    }
    IEnumerator FazerFade()
    {
        Debug.Log("Iniciou o Fade...");
        Color cor = fadeImage.color;

        while (cor.a > 0f)
        {
            cor.a -= velocidadeFade * Time.unscaledDeltaTime;

            if (cor.a < 0f)
            {
                cor.a = 0f;
                fadePanel.SetActive(false); // Desativa o painel de fade quando estiver totalmente transparent
            }

            fadeImage.color = cor;

            yield return null;
        }

        Debug.Log("Fade concluído. Restaurando Time.timeScale...");
        Time.timeScale = 1f;

      
    }
}