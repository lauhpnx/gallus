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
        // O Unity guarda quem bateu no inimigo dentro dessa variável 'collision'
        // Nós checamos: "A etiqueta de quem bateu em mim é 'Ovo'?"
        if (collision.CompareTag("Ovo"))
        {
            // Se for o ovo, o inimigo se destrói!
            Destroy(gameObject);
            MoneyManager.Instance.AdicionarDinheiro(5);
            morteDaBizerra = GetComponent<AudioSource>();
            // E também destrói o ovo que bateu nele para o tiro não atravessar direto
            Destroy(collision.gameObject);
            // Dá o dano na galinha
            collision.GetComponent<GalinhaController>().TakeDamage(damage);
        }
        if (collision.CompareTag("Player"))
        {
            // Se for o ovo, o inimigo se destrói!
            Destroy(gameObject);
            MoneyManager.Instance.AdicionarDinheiro(5);
            morteDaBizerra = GetComponent<AudioSource>();
            // E também destrói o ovo que bateu nele para o tiro não atravessar direto
            // Dá o dano na galinha
            collision.GetComponent<GalinhaController>().TakeDamage(damage);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
