using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("historia"); // nome da sua cena
    }
}