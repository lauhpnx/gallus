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
        float Yaleatoria;
        bool posicaoValida;

        do
        {
            posicaoValida = true;
            Yaleatoria = Random.Range(alturaMinima, alturaMaxima);

            foreach (Transform filho in transform)
            {
                if (Mathf.Abs(filho.position.y - Yaleatoria) < distanciaMinimaY)
                {
                    posicaoValida = false;
                    break;
                }
            }

        } while (!posicaoValida);

        int indiceAleatorio = Random.Range(0, colunasX.Length);
        float XAleatorio = colunasX[indiceAleatorio];

        Vector3 posicaoSpawn = new Vector3(XAleatorio, Yaleatoria, 0f);

        GameObject novoGalo = Instantiate(
            inimigoPrefab,
            posicaoSpawn,
            Quaternion.identity,
            transform
        );

        inimigosSpawnados++;

        float velocidadeAleatoria =
            Random.Range(velocidadeMinima, velocidadeMaxima);

        inimigo scriptInimigo = novoGalo.GetComponent<inimigo>();

        if (scriptInimigo != null)
        {
            scriptInimigo.xFixo = XAleatorio;
            scriptInimigo.VelocidadeOndulação = velocidadeAleatoria;
        }
    }
}