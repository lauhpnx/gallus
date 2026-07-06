using UnityEngine;
using UnityEngine.SceneManagement;

public class abrirLoja : MonoBehaviour
{
    // Nome ou número da cena que você quer carregar (mude no Inspetor da Unity)
    public string loja = "loja";

    void Update()
    {
        // essa linha abaixo verifica se a tecla L foi clicada
        if (Input.GetKeyDown(KeyCode.L))
        {
            CarregarCena();
        }
    }

    public void CarregarCena()
    {
        SceneManager.LoadScene(loja);
    }
}