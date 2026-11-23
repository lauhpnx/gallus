using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voltarjogo : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Debug.Log("saiu do jogo");
    }
    public void BackGame()
    {
        SceneManager.LoadScene("vitoria");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}