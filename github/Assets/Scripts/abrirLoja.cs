using UnityEngine;
using UnityEngine.SceneManagement;

public class abrirLoja : MonoBehaviour
{
    // Nome ou número da cena que você quer carregar (mude no Inspetor da Unity)
    public string loja = "loja";

    void Update()
    {
        // Verifica se Ctrl e Shift estão pressionados E se a tecla F acabou de ser clicada
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) &&
            (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) &&
            Input.GetKeyDown(KeyCode.F))
        {
            CarregarCena();
        }
    }

    void CarregarCena()
    {
        SceneManager.LoadScene(loja);
    }
}