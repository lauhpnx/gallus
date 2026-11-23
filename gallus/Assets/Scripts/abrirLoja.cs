using UnityEngine;
using UnityEngine.SceneManagement;

public class abrirLoja : MonoBehaviour
{
   
    public GameObject painelLoja;

    void Start()
    {
       
            painelLoja.SetActive(false);
        Time.timeScale = 1f;
      
    }
    public void PainelLojaAberto()
    {
        painelLoja.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PainelLojaFechado()
    {
        painelLoja.SetActive(false);
        Time.timeScale = 1f;
    }
}
