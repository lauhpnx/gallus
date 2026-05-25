using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [Header("Configurações do Gerador de Inimigos")]
    public GameObject inimigoPrefab;
    public int limiteInimigos = 2;

    [Header("Configurações das Camadas (Eixo X)")]
    // Em vez de um X fixo, criamos uma lista de colunas (ex: camada de trás, meio e frente)
    public float[] colunasX = { 3f, 4f, 5f };

    [Header("Limite De Altura (Eixo Y)")]
    public float alturaMinima = -4f;
    public float alturaMaxima = 4f;

    [Header("Configurações de Fim da Fase")]
    public int maxdeInimigos = 15;
    private int inimigosSpawnados = 0;

    [Header("Configurações de Velocidade Aleatória")]
    public float velocidadeMinima = 2f;
    public float velocidadeMaxima = 6f;

    void Start()
    {
        // Vazio por enquanto, igual o seu
    }

    void Update()
    {
        int quantidadedeGalosvivos = transform.childCount;

        // Se tiver menos galos vivos que o limite E ainda não spawnou o máximo da fase
        if (quantidadedeGalosvivos < limiteInimigos && inimigosSpawnados < maxdeInimigos)
        {
            SpawnarGalo();
        }
    } // <-- O Update FECHA aqui!

    // A função SpawnarGalo fica do lado de fora do Update
    void SpawnarGalo()
    {
        // 1. Sorteia a altura (igual você fez)
        float Yaleatoria = Random.Range(alturaMinima, alturaMaxima);

        // 2. NOVO: Sorteia uma das camadas X da nossa lista
        int indiceAleatorio = Random.Range(0, colunasX.Length);
        float XAleatorio = colunasX[indiceAleatorio];

        // 3. Monta a posição com o X e Y sorteados
        Vector3 posicaoSpawn = new Vector3(XAleatorio, Yaleatoria, 0f);

        // 4. Instancia o inimigo como filho deste Gerador (para o childCount funcionar)
        GameObject novoGalo = Instantiate(inimigoPrefab, posicaoSpawn, Quaternion.identity, transform);

        // 5. Conta que mais um inimigo nasceu
        inimigosSpawnados = inimigosSpawnados + 1; // Ou inimigosSpawnados++;

        // 6. NOVO: Sorteia uma velocidade e envia para o script do Inimigo que acabou de nascer
        float velocidadeAleatoria = Random.Range(velocidadeMinima, velocidadeMaxima);

        inimigo scriptInimigo = novoGalo.GetComponent<inimigo>();
        if (scriptInimigo != null)
        {
            scriptInimigo.xFixo = XAleatorio; // Garante que ele use a camada sorteada
            scriptInimigo.VelocidadeOndulação = velocidadeAleatoria; // Dá a velocidade única dele
        }
    }
}