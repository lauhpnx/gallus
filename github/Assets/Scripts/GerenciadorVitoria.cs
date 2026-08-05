using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorVitoria : MonoBehaviour
{
    [Header("UI de Vitória")]
    public GameObject painelVitoria;
    public string nomeProximaFase = "fase2";

    [Header("Condição: Matar Inimigos")]
    public int totalInimigosNaFase = 10; 
    private int inimigosDerrotados;

    void Start()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }

        // Removida a linha que contava na cena, pois zerava com Spawner
    }

    public void RegistrarMorteInimigo()
    {
        inimigosDerrotados++;

        // Garante que só ganha se a meta for maior que 0 e atingida
        if (totalInimigosNaFase > 0 && inimigosDerrotados >= totalInimigosNaFase)
        {
            GanhouAFase();
        }
    }

    public void GanhouAFase()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void CarregarProximaFase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeProximaFase);
    }

    public void CarregarProximaFase3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Fase3");
    }
}