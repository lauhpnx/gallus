using System.Collections;
using TMPro;
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
    public TextMeshProUGUI TextoWarningPrefab;
    public Animator animacaoWarning;
    public float Velocidade = 1f;
    public float tempoDeAviso = 1f;

    private bool chovendoAgora = false;
    private bool cicloiniciado = false;

    void Start()
    {
        if (TextoWarningPrefab != null)
        {
            TextoWarningPrefab.text = "PERIGO! OVOS PODRES ESTÃO\r\nCAINDO DO CÉU, CUIDADO!";
            Color corInicial = TextoWarningPrefab.color;
            corInicial.a = 0f;
            TextoWarningPrefab.color = corInicial;
        }
        if(animacaoWarning != null)
        {
            animacaoWarning.enabled = false;
        }
    }
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
        yield return StartCoroutine(MostrarAvisoDeChuva());
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
    IEnumerator MostrarAvisoDeChuva()
    {
        if (TextoWarningPrefab == null) yield break;
        {
            TextoWarningPrefab.text = "PERIGO! OVOS PODRES ESTÃO\r\nCAINDO DO CÉU, CUIDADO!";
            Color cor = TextoWarningPrefab.color;
            cor.a = 0f;
            TextoWarningPrefab.color = cor;

            while (cor.a < 1f)
            {
                cor.a += Velocidade * Time.unscaledDeltaTime;
                if (cor.a > 1f) cor.a = 1f;

                TextoWarningPrefab.color = cor;
                yield return null;
            }
        }
        if (animacaoWarning != null)
        {
            animacaoWarning.enabled = true;
        }
    }
}