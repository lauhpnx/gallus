using System.Collections;
using UnityEngine;

public class SpawnOvoPodre : MonoBehaviour
{
    public GameObject prefab;
    public float SpawnFrequency;
    private float _timer;

    public Transform left;
    public Transform right;

    [Header("Configurações de Spawn")]
    public float TempoChovendo;
    public float TempoEntreChuva;

    [Header("Aviso de Perigo")]
    public GameObject avisoPrefab;
    public float tempoDeAviso = 0.4f;

    private bool chovendoAgora = false;
    private bool cicloiniciado = false;

    public void iniciarchuvaFuria()
    {
        if (!cicloiniciado)
        {
            StartCoroutine(RotinaDeChuva());
            cicloiniciado = true;
        }
    }

    IEnumerator RotinaDeChuva()
    {
        while (true)
        {
            chovendoAgora = true;
            yield return new WaitForSeconds(TempoChovendo);
            chovendoAgora = false;
            yield return new WaitForSeconds(TempoEntreChuva);
        }
    }

    public void Update()
    {
        if (chovendoAgora)
        {
            GerarOvosContinuos();
        }
    }

    private void GerarOvosContinuos()
    {
        if (left != null && right != null && prefab != null)
        {
            _timer += Time.deltaTime;
            if (_timer >= SpawnFrequency)
            {
                _timer = 0f;

                float newX = Random.Range(left.position.x, right.position.x);
                Vector3 posicaoDeSpawn = new Vector3(newX, transform.position.y, transform.position.z);

                StartCoroutine(AvisarEDepoisSpawnar(posicaoDeSpawn));
            }
        }
    }

    private IEnumerator AvisarEDepoisSpawnar(Vector3 posicao)
    {
        GameObject aviso = null;
        if (avisoPrefab != null)
        {
            aviso = Instantiate(avisoPrefab, posicao, Quaternion.identity);
        }

        yield return new WaitForSeconds(tempoDeAviso);

        if (aviso != null)
        {
            Destroy(aviso);
        }

        Instantiate(prefab, posicao, Quaternion.identity);
    }
}