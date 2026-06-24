using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaPersonagem : MonoBehaviour
{
    public int vidaMaxima = 10;
    public int vidaAtual = 10;

    public Slider barraVida;

    void Start()
    {
        barraVida.maxValue = vidaMaxima;
        barraVida.value = vidaAtual;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        barraVida.value = vidaAtual;

        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}