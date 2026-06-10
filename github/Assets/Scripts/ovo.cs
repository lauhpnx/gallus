using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f; // Destr�i ap�s 3 segundos

    void Start()
    {
        // Faz o ovo se mover para a frente (direita) assim que nasce
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * velocidade;

        // Destr�i o objeto automaticamente para limpar a mem�ria
        Destroy(gameObject, tempoDeVida);
    }
}