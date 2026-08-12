using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f;

    public GameObject explosaoPrefab;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            
            rb.linearVelocity = transform.right * velocidade;
            
        }

            // Destrói apenas o ovo. O script de vida do Galo cuida do resto!
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Galo"))
        {
            if (explosaoPrefab != null)
            {
                Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
            }

            
            Destroy(gameObject);
        }
    }
}