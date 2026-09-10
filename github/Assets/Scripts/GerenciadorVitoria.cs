using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorVitoria : MonoBehaviour
{
    [Header("UI de Vitória")]
    public GameObject painelVitoria;

    [Header("Condição: Matar Inimigos")]
    public int totalInimigosNaFase = 10;

    private int inimigosDerrotados = 0;

    private bool faseGanha = false;


    void Start()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }

        Time.timeScale = 1f;
    }


    public void RegistrarMorteInimigo()
    {
        if (faseGanha)
        {
            return;
        }

        inimigosDerrotados++;

        Debug.Log("Inimigos derrotados: " + inimigosDerrotados);

        if (totalInimigosNaFase > 0 &&
            inimigosDerrotados >= totalInimigosNaFase)
        {
            faseGanha = true;

            Debug.Log("TODOS OS INIMIGOS FORAM DERROTADOS!");

            string cenaAtual = SceneManager.GetActiveScene().name;

            if (cenaAtual == "fase1")
            {
                Time.timeScale = 1f;

                SceneManager.LoadScene("fase2");
            }

            else if (cenaAtual == "fase2")
            {
                Time.timeScale = 1f;

                SceneManager.LoadScene("Fase3");
            }
            else if (cenaAtual == "Fase3")
            {
                FadeVictory fade = FindFirstObjectByType<FadeVictory>();
                if (fade != null)
                {
                    fade.IrParaVitoria();
                }
                else
                {
                    Debug.LogWarning(
                        "FadeVictory não foi encontrado na Fase3!"
                    );
                }
            }
        }
    }

    public void GanhouAFase()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void CarregarProximaFase()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("fase2");
    }
    public void CarregarProximaFase3()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Fase3");
    }
}