using UnityEngine;

public class inimigo : MonoBehaviour
{
    [Header("configurações da camada")]
    public float xFixo = 5f;

    [Header("configurações de movimento")]
    public float VelocidadeOndulação = 3f;
    public float Amplitude = 1.5f; 
    public float velocidadeDescida = 3f;


    [Header("Limites de Tela (Barreira Invisível)")]
    // Valores padrão que costumam travar bem na tela
    public float limiteTeto = 25f;
    public float limiteChao = -25f;

    private float yinicial;

    private AudioSource morteDaBizerra;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yinicial = transform.position.y;
       

    }

    // Update is called once per frame
    void Update()
    {
        float novaY = yinicial + Mathf.Sin(Time.time * VelocidadeOndulação) * Amplitude;

        //novaY = Mathf.Clamp(novaY, limiteChao, limiteTeto);

        transform.position = new Vector3(xFixo, novaY, 0f);
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
        }
    }
}
