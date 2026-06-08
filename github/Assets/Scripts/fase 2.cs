using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class fase2 : MonoBehaviour
{
    public GameObject botaofase2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void JogadorGanhou()
    {
        botaofase2.SetActive(true);
    }

     // Update is called once per frame
   
    public void CarregarFase2()
    {
        SceneManager.LoadScene("Fase2");
    }
}