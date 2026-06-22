using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f; // Destrói após 3 segundos

    public GameObject explosaoPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Corrigido: Agora checa se o objeto que tomou o tiro (collision) é o Galo
        if (collision.CompareTag("Galo"))
        {
            Instantiate(

                explosaoPrefab,
                transform.position,
                Quaternion.identity

                );

            // Destrói apenas o ovo. O script de vida do Galo cuida do resto!
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Faz o ovo se mover para a frente (direita) assim que nasce
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * velocidade;

        // Destrói o objeto automaticamente para limpar a memória
        Destroy(gameObject, tempoDeVida);
    }
}