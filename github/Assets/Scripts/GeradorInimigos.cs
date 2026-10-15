using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    public static GeradorInimigos Instance;
    public GameObject prefab;
    public float SpawnFrequency = 2f;
    private float _timer;
    public bool isSpawning =  false;
    public GerenciadorVitoria gInim;
    public BossHealth bossHealth;

    public Transform left;
    public Transform right;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= SpawnFrequency && !isSpawning)
        {
            GameObject enemy = Instantiate(prefab);

            float newY = Random.Range(left.position.y, right.position.y);

            enemy.transform.position = new Vector3(transform.position.x, newY, 0);

            _timer = 0f;
        }
    }
}