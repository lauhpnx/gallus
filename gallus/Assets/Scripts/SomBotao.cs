using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotaoComSom : MonoBehaviour
{
    public AudioSource audioSource;
    public string nomeDaCena;
    public float tempoEspera = 0.5f;

    public void ClicarBotao()
    {
        audioSource.Play();
        StartCoroutine(TrocarCena());
    }

    IEnumerator TrocarCena()
    {
        yield return new WaitForSeconds(tempoEspera);
        SceneManager.LoadScene(nomeDaCena);
    }
}