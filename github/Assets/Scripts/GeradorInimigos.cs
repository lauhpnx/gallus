using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [Header("Configurações do Gerador de Inimigos")]
    [Header("Configurações do Gerador de Inimigos")]
    public GameObject inimigoPrefab;
    public int limiteInimigos = 2;
    public float posicaoXSpawn = 10f;
    [Header("LimiteDeAltura")]
    public float alturaMinima = -4f;
    public float alturaMaxima = 4f;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        int quantidadedeGalosvivos = transform.childCount;

        if (quantidadedeGalosvivos < limiteInimigos)
        {
            SpawnarGalo();
        }

    }
    void SpawnarGalo()
    {
        float Yaleatoria = Random.Range(alturaMinima, alturaMaxima);
        Vector3 posicaoSpawn = new Vector3(posicaoXSpawn, Yaleatoria, 0f);
   
        GameObject novoGalo = Instantiate(inimigoPrefab, posicaoSpawn, Quaternion.identity, transform);
    }
}
