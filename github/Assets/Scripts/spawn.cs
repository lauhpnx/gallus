using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab; // O prefab do milho
    public float SpawnFrequency;
    private float _timer;

    public Transform left;
    public Transform right;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= SpawnFrequency)
        {
            // 1. Sorteia o X aleatório entre os limites da esquerda e direita
            float newX = Random.Range(left.position.x, right.position.x);

            // 2. Define a posição de nascimento: X sorteado, mas o Y e Z fixos do Spawner (lá de cima)
            Vector3 posicaoDeSpawn = new Vector3(newX, transform.position.y, transform.position.z);

            // 3. Instancia o milho diretamente na posição correta
            GameObject milho = Instantiate(prefab, posicaoDeSpawn, Quaternion.identity);

            _timer = 0f;
        }
    }
}