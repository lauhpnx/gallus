using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f;
    private Rigidbody2D rb;

    public GameObject explosaoPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Corrigido: Agora checa se o objeto que tomou o tiro (collision) é o Galo
        if (collision.CompareTag("Galo"))
        {
            Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
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
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {

            rb.linearVelocity = transform.right * velocidade;

        }


        Destroy(gameObject, tempoDeVida);
    }

}