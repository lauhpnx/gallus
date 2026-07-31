using UnityEngine;
using UnityEngine.SceneManagement; 

public class GerenciadorVitoria : MonoBehaviour
{
    [Header("UI de Vitória")]
    public GameObject painelVitoria; 
    public string nomeProximaFase = "fase2"; 

    [Header("Condição: Matar Inimigos")]
    public int totalInimigosNaFase;
    private int inimigosDerrotados;

    void Start()
    {
       
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(false);
        }
        totalInimigosNaFase = GameObject.FindGameObjectsWithTag("Inimigo").Length;
    }
    public void RegistrarMorteInimigo()
    {
        inimigosDerrotados++;
        if (inimigosDerrotados >= totalInimigosNaFase)
        {
            GanhouAFase();
        }
    }

   
    public void GanhouAFase()
    {
        Debug.Log("Vitória! Fase concluída!");

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
}