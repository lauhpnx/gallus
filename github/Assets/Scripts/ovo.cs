using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f; // Destr�i ap�s 3 segundos

    public GameObject explosaoPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (explosaoPrefab.CompareTag("Galo"))
        {
            Instantiate(

                explosaoPrefab,
                transform.position,
                Quaternion.identity

                );
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Faz o ovo se mover para a frente (direita) assim que nasce
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * velocidade;

        // Destr�i o objeto automaticamente para limpar a mem�ria
        Destroy(gameObject, tempoDeVida);
    }
}