using UnityEngine;
using UnityEngine.SceneManagement;

public class painelTuto : MonoBehaviour

{
    public GameObject painelTutorial;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        painelTutorial.SetActive(false);
    }

    // Update is called once per frame
    public void PainelCreditosAberto()
    {
        painelTutorial.SetActive(true);
    }

    public void PainelCreditosFechado()
    {
        painelTutorial.SetActive(false);
    }
}
