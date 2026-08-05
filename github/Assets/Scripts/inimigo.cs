using UnityEngine;

public class inimigo : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 5f;
    public int damage = 1;
    private AudioSource morteDaBizerra;

    private bool foiDerrotado = false; 

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.CompareTag("Ovo"))
        {
            foiDerrotado = true;

            
            GerenciadorVitoria gerenciador = FindFirstObjectByType<GerenciadorVitoria>();
            if (gerenciador != null)
            {
                gerenciador.RegistrarMorteInimigo();
            }

          
            if (MoneyManager.Instance != null)
            {
                MoneyManager.Instance.AdicionarDinheiro(5);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);           
        }
        if (collision.CompareTag("Player"))
        {
            foiDerrotado = true;

            GalinhaController galinha = collision.GetComponent<GalinhaController>();
            if (galinha != null)
            {
                galinha.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        if (!foiDerrotado)
        {
            foiDerrotado = true;

            GalinhaController galinha = FindFirstObjectByType<GalinhaController>();
            if (galinha != null)
            {
                galinha.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}