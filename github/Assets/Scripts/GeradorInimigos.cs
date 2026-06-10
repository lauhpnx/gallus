using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [Header("Configurações do Gerador de Inimigos")]
    public GameObject inimigoPrefab;
    public int limiteInimigos = 2;

    [Header("Configurações das Camadas (Eixo X)")]
    public float[] colunasX = { 3f, 4f, 5f };

    [Header("Limite De Altura (Eixo Y)")]
    public float alturaMinima = -17f;
    public float alturaMaxima = 17f;

    [Header("Configurações de Fim da Fase")]
    public int maxdeInimigos = 15;
    private int inimigosSpawnados = 0;

    [Header("Configurações de Velocidade Aleatória")]
    public float velocidadeMinima = 2f;
    public float velocidadeMaxima = 6f;

    [Header("Tempo Entre Spawns")]
    public float tempoEntreSpawns = 2f;
    private float proximoSpawn = 0f;

    [Header("Distância Mínima Entre Galos")]
    public float distanciaMinimaY = 1.5f;

    void Update()
    {
        int quantidadedeGalosvivos = transform.childCount;

        if (Time.time >= proximoSpawn &&
            quantidadedeGalosvivos < limiteInimigos &&
            inimigosSpawnados < maxdeInimigos)
        {
            SpawnarGalo();

            proximoSpawn = Time.time + tempoEntreSpawns;
        }
    }

    void SpawnarGalo()
    {
        float Yaleatoria; // Removi o = 0f daqui para ficar igual ao seu original
        float XAleatorio; // Criada aqui fora para o Unity não dar erro de escopo
        bool posicaoValida;
        int tentativas = 0; // Evita travar o Unity se a tela estiver cheia

        do
        {
            posicaoValida = true;

            // 1. Sorteia a coluna (X) primeiro
            int indiceAleatorio = Random.Range(0, colunasX.Length);
            XAleatorio = colunasX[indiceAleatorio]; // Sem o "float" na frente!

            // 2. Sorteia a altura (Y)
            Yaleatoria = Random.Range(alturaMinima, alturaMaxima);

            // 3. Varre os inimigos na tela
            foreach (Transform filho in transform)
            {
                // Checa se o inimigo já existente está na mesma coluna X que sorteamos
                if (Mathf.Abs(filho.position.x - XAleatorio) < 0.2f)
                {
                    // Se sim, checa se a distância vertical (Y) é muito curta
                    if (Mathf.Abs(filho.position.y - Yaleatoria) < distanciaMinimaY)
                    {
                        posicaoValida = false;
                        break; // Sai do foreach para sortear de novo no do-while
                    }
                }
            }

            // Segurança para não travar o PC
            tentativas++;
            if (tentativas > 50)
            {
                Debug.LogWarning("Muitos inimigos na tela! Parando sorteio para não travar o jogo.");
                break;
            }

        } while (!posicaoValida);

        // Daqui para baixo está iguaizinho ao seu código original original!
        Vector3 posicaoSpawn = new Vector3(XAleatorio, Yaleatoria, 0f);

        GameObject novoGalo = Instantiate(
            inimigoPrefab,
            posicaoSpawn,
            Quaternion.identity,
            transform
        );

        inimigosSpawnados++;

        float velocidadeAleatoria = Random.Range(velocidadeMinima, velocidadeMaxima);

        inimigo scriptInimigo = novoGalo.GetComponent<inimigo>();

        if (scriptInimigo != null)
        {
            scriptInimigo.xFixo = XAleatorio;
            scriptInimigo.VelocidadeOndulação = velocidadeAleatoria;
        }
    }
}