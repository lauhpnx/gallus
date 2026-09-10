using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

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
    public float maxHealth = 60f;
    private float currentHealth;

    [Header("UI do Chefe (Barra de Vida)")]
    public Image healthBarImage;

    [Header("--- MECÂNICAS DA FASE DE FÚRIA ---")]
    [Header("Ataque 2: Penas Perseguidoras")]
    public GameObject penaPrefab;
    public Transform pontoDeTiro;
    public GameObject PontoDeTiro2;
    public float tempoTiroFuria;
    private float cronometroTiro;
    public float TempoTiroFuria2;
    private bool PrimeiraPenaAtirada;
    private bool SegundaPenaAtirada;

    [Header("Invocação: Spawnar Galos Minions")]
    public GameObject galoMinionPrefab;
    public Transform left;
    public Transform right;
    public Transform center;

    public float tempoSpawn = 5f;
    private float cronometroSpawn;

    [Header("Estado do Boss")]
    public bool emFuria = false;
    public GameObject efeitoMortePrefab;
    public float tempoDeEspera = 2.0f;


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
        SpawnarGalosMinions();

        if (emFuria)
        {
            AtirarPenasPerseguidoras();

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
        if (!PrimeiraPenaAtirada && cronometroTiro >= tempoTiroFuria)
        {
            PrimeiraPenaAtirada = true;
            Instantiate(penaPrefab, pontoDeTiro.position, Quaternion.identity);
        }
        if (!SegundaPenaAtirada && cronometroTiro >= TempoTiroFuria2)
        {
            Instantiate(penaPrefab, PontoDeTiro2.transform.position, Quaternion.identity);
            SegundaPenaAtirada = true;
            cronometroTiro = 0f;
            PrimeiraPenaAtirada = false;
            SegundaPenaAtirada = false;
        }
    }

    void SpawnarGalosMinions()
    {
        if (galoMinionPrefab == null || left == null || right == null) return;

        cronometroSpawn += Time.deltaTime;
        if (cronometroSpawn >= tempoSpawn)
        {
            float newY = Random.Range(left.position.y, right.position.y);
            Vector3 spawnPosition = new Vector3(left.position.x, newY, left.position.z);
            Instantiate(galoMinionPrefab, spawnPosition, Quaternion.identity);
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
        if (efeitoMortePrefab != null)
        {
            Instantiate(efeitoMortePrefab, transform.position, Quaternion.identity);
        }
        StartCoroutine(EsperarTrocarDeCena());

        Destroy(gameObject);
    }

    private IEnumerator EsperarTrocarDeCena()
    {
        yield return new WaitForSeconds(tempoDeEspera); 
        SceneManager.LoadScene("vitoria");
    }
    private void DesativarBoss()
    {
        if (GetComponent<Renderer>() != null) GetComponent<Renderer>().enabled = false;
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);



            }
            if (GetComponent<Collider>() != null) GetComponent<Collider>().enabled = false;
            if (GetComponent<Collider2D>() != null) GetComponent<Collider2D>().enabled = false;
        }
    }
}