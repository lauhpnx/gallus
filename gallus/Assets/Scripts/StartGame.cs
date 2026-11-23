using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource audioSource;
    public float tempoEspera = 0.5f;
    public void ClicarBotao()
    {
        audioSource.Play();
        StartCoroutine(TrocarCena());
    }

    IEnumerator TrocarCena()
    {
        yield return new WaitForSeconds(tempoEspera);
        SceneManager.LoadScene("historia");
    }
}
