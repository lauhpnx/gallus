using UnityEngine;

public class inimigo : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 5f;
    public int damage = 1;
    private AudioSource morteDaBizerra;

    private bool foiDerrotado = false; // Evita que dê dano duplo se sumir e colidir ao mesmo tempo

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Inimigo colidiu com: " + collision.gameObject.name + " | Tag: " + collision.tag);

        // 🥚 Se colidiu com o OVO (Jogador acertou o tiro)
        if (collision.CompareTag("Ovo"))
        {
            foiDerrotado = true; // Marca que foi morto pelo jogador

            // Conta vitória
            GerenciadorVitoria gerenciador = FindFirstObjectByType<GerenciadorVitoria>();
            if (gerenciador != null)
            {
                gerenciador.RegistrarMorteInimigo();
            }

            // Dá dinheiro
            if (MoneyManager.Instance != null)
            {
                MoneyManager.Instance.AdicionarDinheiro(5);
            }

            Destroy(collision.gameObject); // Destrói o ovo
            Destroy(gameObject); // Destrói o inimigo
        }

        // 🐔 Se colidiu com o PLAYER (Bateu na galinha)
        if (collision.CompareTag("Player"))
        {
            foiDerrotado = true; // Marca que já causou impacto

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

            Destroy(gameObject); // Destrói o inimigo
        }
    }

    // 🚪 Chamado quando o inimigo sai completamente da tela sem ser atingido
    private void OnBecameInvisible()
    {
        // Só dá dano se ele saiu da tela VIVO (sem ter colidido com o Ovo/Player)
        if (!foiDerrotado)
        {
            foiDerrotado = true;

            GalinhaController galinha = FindFirstObjectByType<GalinhaController>();
            if (galinha != null)
            {
                galinha.TakeDamage(damage);
                Debug.Log("⚠️ Inimigo escapou da tela e causou dano à Galinha!");
            }

            Destroy(gameObject);
        }
    }
}