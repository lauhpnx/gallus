using UnityEngine;

public class inimigo : MonoBehaviour
{
     [Header("Enemy Settings")]
    public float speed = 5f;
    public int damage = 1;
    private AudioSource morteDaBizerra;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Esta linha VAI IMPRIMIR qualquer coisa que encostar no inimigo
        Debug.Log("Inimigo colidiu com: " + collision.gameObject.name + " | Tag: " + collision.tag);

       
        GerenciadorVitoria gerenciador = FindFirstObjectByType<GerenciadorVitoria>();
        if (gerenciador != null)
        {
            gerenciador.RegistrarMorteInimigo();
        }

        Destroy(gameObject); // Destrói o inimigo
        if (collision.CompareTag("Ovo"))
        {
            Destroy(gameObject);
            if (MoneyManager.Instance != null) MoneyManager.Instance.AdicionarDinheiro(5);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            GalinhaController galinha = collision.GetComponent<GalinhaController>();

            if (galinha != null)
            {
                galinha.TakeDamage(damage);
                Debug.Log("DANO ENVIADO COM SUCESSO!");
            }
            else
            {
                Debug.LogError("Bateu no Player, mas NÃO achou o GalinhaController!");
            }

            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
