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


        Destroy(gameObject, tempoDeVida);
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