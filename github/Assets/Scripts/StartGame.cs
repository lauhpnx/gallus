using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("fase1"); // nome da sua cena
    }
}