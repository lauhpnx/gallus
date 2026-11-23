using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{


    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu2(string name)
    {
        SceneManager.LoadScene(name);
    }
}