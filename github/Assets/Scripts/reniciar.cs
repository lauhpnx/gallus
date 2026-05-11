using UnityEngine;
using UnityEngine.SceneManagement;

public class reniciar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReiniciarFase()
    {
        // Obtém o nome da cena que está aberta no momento e a carrega de novo
        string nomeDaCenaAtual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomeDaCenaAtual);
    }
}
