using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleCreditos : MonoBehaviour

{
    public GameObject painelCreditos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        painelCreditos.SetActive(false);
    }

    // Update is called once per frame
    public void PainelCreditosAberto()
    {
        painelCreditos.SetActive(true);
    }

    public void PainelCreditosFechado()
    {
        painelCreditos.SetActive(false);
    }
}
