using UnityEngine;
using UnityEngine.UI; // Necessário para acessar o componente Image

public class BossHealth : MonoBehaviour
{
    [Header("configurações da camada")]
    public float xFixo = 5f;

    [Header("configurações de movimento")]
    public float VelocidadeOndulação = 3f;
    public float Amplitude = 1.5f;

    [Header("Limites de Tela (Barreira Invisível)")]
    // Valores padrão que costumam travar bem na tela
    public float limiteTeto = 17f;
    public float limiteChao = -17f;

    private float yinicial;

    private AudioSource morteDaBizerra;
    [Header("Configurações de Vida")]
    public float maxHealth = 50f; // Mudado para float para o cálculo da barra funcionar perfeitamente
    private float currentHealth;

    [Header("UI do Chefe (Barra de Vida)")]
    public Image healthBarImage; // Arraste a sua IMAGEM FILLED para cá no Inspetor

    void Start()
    {
        currentHealth = maxHealth;

        // Garante que a barra comece cheia (1f significa 100% preenchida)
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = 1f;
        }
        yinicial = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ovo"))
        {
            TakeDamage(1f); // Tira 1 de vida por tiro
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Atualiza a barra de vida proporcionalmente
        if (healthBarImage != null)
        {
            // Divide a vida atual pela máxima para conseguir um valor entre 0 e 1
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("O Galo foi derrotado!");

        // Opcional: Opcionalmente destrói ou esconde a barra de vida ao morrer
        if (healthBarImage != null && healthBarImage.transform.parent != null)
        {
            // Destrói o "Pai" da imagem (o container/borda da barra) se quiser sumir com tudo
            Destroy(healthBarImage.transform.parent.gameObject);
        }

        Destroy(gameObject);
    }
    void Update()
    {
        float novaY = yinicial + Mathf.Sin(Time.time * VelocidadeOndulação) * Amplitude;

        novaY = Mathf.Clamp(novaY, limiteChao, limiteTeto);

        transform.position = new Vector3(xFixo, novaY, 0f);
    }
}