using UnityEngine;

public class ovo : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 3f; // Destrói após 3 segundos

    public GameObject explosaoPrefab;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Aponta e move o ovo na direção para onde ele foi rotacionado (reto ou diagonal)
            rb.linearVelocity = transform.right * velocidade;
            // NOTA: Se o seu Unity for antigo (2022 ou anterior) e der erro no 'linearVelocity', mude para 'rb.velocity'
        }

        // Destrói o objeto automaticamente para limpar a memória
        Destroy(gameObject, tempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checa se o objeto que tomou o tiro é o Galo
        if (collision.CompareTag("Galo"))
        {
            if (explosaoPrefab != null)
            {
                Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
            }

            // Destrói apenas o ovo
            Destroy(gameObject);
        }
    }
}