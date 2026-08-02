using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class BossHealth : MonoBehaviour
{
    [Header("Configurações da Camada")]
    public float xFixo = 5f;

    [Header("Configurações de Movimento")]
    public float VelocidadeOndulação = 3f;
    public float Amplitude = 1.5f;

    [Header("Limites de Tela (Barreira Invisível)")]
    public float limiteTeto = 17f;
    public float limiteChao = -17f;

    private float yinicial;
    private AudioSource morteDaBizerra;

    [Header("Configurações de Vida")]
    public float maxHealth = 50f;
    private float currentHealth;

    [Header("UI do Chefe (Barra de Vida)")]
    public Image healthBarImage;

    [Header("--- MECÂNICAS DA FASE DE FÚRIA ---")]
    [Header("Ataque 2: Penas Perseguidoras")]
    public GameObject penaPrefab;
    public Transform pontoDeTiro;
    public float tempoTiroFuria = 2.5f;
    private float cronometroTiro;

    [Header("Invocação: Spawnar Galos Minions")]
    public GameObject galoMinionPrefab;
    public Transform pontoSpawnMinion;
    public float tempoSpawn = 5f;
    private float cronometroSpawn;

    [Header("Estado do Boss")]
    public bool emFuria = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = 1f;
        }

        yinicial = transform.position.y;
    }

    void Update()
    {
    
        float velocidadeAtual = emFuria ? VelocidadeOndulação * 1.5f : VelocidadeOndulação;
        float novaY = yinicial + Mathf.Sin(Time.time * velocidadeAtual) * Amplitude;
        novaY = Mathf.Clamp(novaY, limiteChao, limiteTeto);
        transform.position = new Vector3(xFixo, novaY, 0f);

       
        if (emFuria)
        {
            AtirarPenasPerseguidoras();
            SpawnarGalosMinions();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ovo"))
        {
            TakeDamage(1f);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

       
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = currentHealth / maxHealth;
        }

        
        if (!emFuria && currentHealth <= (maxHealth / 2f))
        {
            AtivarFuria();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void AtivarFuria()
    {
        emFuria = true;
        Debug.Log("🔥 O GALO ENTROU EM FÚRIA! Começando a invocar e atirar penas!");
    }

    void AtirarPenasPerseguidoras()
    {
        if (penaPrefab == null || pontoDeTiro == null) return;

        cronometroTiro += Time.deltaTime;
        if (cronometroTiro >= tempoTiroFuria)
        {
            Instantiate(penaPrefab, pontoDeTiro.position, Quaternion.identity);
            cronometroTiro = 0f;
        }
    }

    void SpawnarGalosMinions()
    {
        if (galoMinionPrefab == null || pontoSpawnMinion == null) return;

        cronometroSpawn += Time.deltaTime;
        if (cronometroSpawn >= tempoSpawn)
        {
            Instantiate(galoMinionPrefab, pontoSpawnMinion.position, Quaternion.identity);
            cronometroSpawn = 0f;
        }
    }

    void Die()
    {
        Debug.Log("O Galo foi derrotado!");

       
        GerenciadorVitoria gerenciador = FindFirstObjectByType<GerenciadorVitoria>();
        if (gerenciador != null)
        {
            gerenciador.GanhouAFase();
        }

        
        if (healthBarImage != null && healthBarImage.transform.parent != null)
        {
            Destroy(healthBarImage.transform.parent.gameObject);
        }

        Destroy(gameObject);
        SceneManager.LoadScene("Vitoria");
    }
}