using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GerenciadorVitoria : MonoBehaviour
{

    [Header("UI de Vitória")]
    public GameObject painelVitoria;

    [Header("Condição: Matar Inimigos")]
    public int totalInimigosNaFase = 10;
    private int inimigosDerrotados = 0;
    private bool faseGanha = false;
    public GeradorInimigos gInim;
    public string proximaFase;
    public Image fadeImage;
    public float velocidadeFade = 0.8f;

    void Start()
    {
        Time.timeScale = 1f;

        if (painelVitoria != null)
            painelVitoria.SetActive(false);
        
    }

    public void RegistrarMorteInimigo()
    {
        if (faseGanha) return;

        inimigosDerrotados++;

        if (inimigosDerrotados >= totalInimigosNaFase)
        {
            faseGanha = true;
            GanhouAFase();
        }
    }

    public void GanhouAFase()
    {
    
            StartCoroutine(EsperarTrocarDeCena());
        //painelVitoria.SetActive(true);
        //gInim.isSpawning = true;

    }
    public void proximafase()
    {
        SceneManager.LoadScene(proximaFase);
    }
    IEnumerator EsperarTrocarDeCena()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Iniciou o Fade...");
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
            gInim.isSpawning = true;
        }
        painelVitoria.SetActive(true);
        
    }
}
