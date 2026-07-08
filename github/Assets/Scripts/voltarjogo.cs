using UnityEngine;
using UnityEngine.SceneManagement;

public class voltarjogo : MonoBehaviour
{

    public void BackGame()
    {
        SceneManager.LoadScene("vitoria");
    }
}