using UnityEngine.SceneManagement;
using UnityEngine;

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
        if (painelVitoria != null)
            painelVitoria.SetActive(true);
        gInim.isSpawning = true;

    }
    public void proximafase()
    {
      SceneManager.LoadScene(proximaFase);
    }
}