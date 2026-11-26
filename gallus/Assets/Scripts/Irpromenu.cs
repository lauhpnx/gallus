using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Irpromenu : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

}
