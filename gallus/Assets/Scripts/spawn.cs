using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float SpawnFrequency;
    private float _timer;

    public Transform left;
    public Transform right;

    [Header("Ensinar o Milho (primeira vez)")]
    public int muturacaoMinima = 10; 
    public GameObject avisoMilhoPrefab;
    public float tempoDeAviso = 1.5f;
    private bool primeiroMilhoJaEnsinado = false;

    void Update()
    {
        if (!primeiroMilhoJaEnsinado)
        {
            if (GalinhaController.Instance != null &&
                GalinhaController.Instance.ovosRestantes <= muturacaoMinima)
            {
                SpawnarMilhoComAviso();
                primeiroMilhoJaEnsinado = true;
                _timer = 0f;
            }
            return; 
        }

        _timer += Time.deltaTime;
        if (_timer >= SpawnFrequency)
        {
            float newX = Random.Range(left.position.x, right.position.x);
            Vector3 posicaoDeSpawn = new Vector3(newX, transform.position.y, transform.position.z);
            Instantiate(prefab, posicaoDeSpawn, Quaternion.identity);
            _timer = 0f;
        }
    }

    void SpawnarMilhoComAviso()
    {
        float newX = Random.Range(left.position.x, right.position.x);
        Vector3 posicaoDeSpawn = new Vector3(newX, transform.position.y, transform.position.z);

        Instantiate(prefab, posicaoDeSpawn, Quaternion.identity);

        if (avisoMilhoPrefab != null)
        {
            GameObject aviso = Instantiate(avisoMilhoPrefab, posicaoDeSpawn + Vector3.up * 1f, Quaternion.identity);
           // Destroy(aviso, tempoDeAviso); 
        }
    }
}