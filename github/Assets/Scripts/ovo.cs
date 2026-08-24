using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f;

    private Rigidbody2D rb;

    public GameObject explosaoPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = transform.right * velocidade;
        }

        Destroy(gameObject, tempoDeVida);
    }

    void morrer()
    {
        if (explosaoPrefab != null)
        {
            Instantiate(
                explosaoPrefab,
                transform.position,
                transform.rotation
            );
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galo"))
        {
            morrer();
        }
    }
}
