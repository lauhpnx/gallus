using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class GalinhaController : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int life = 10;
    public int _lifemax = 10;

    [Header("UI do Player (Barra de Vida)")]
    public Image healthBarImage;

    [Header("Movimentação e Limites")]
    public float velocidadeMovimento = 8f;

    [Header("Posicionamento no Eixo X (Horizontal)")]
    public bool usarPosicaoXManual = true;
    public float posicaoX_Manual = -7f;

    [Header("Limites de Cima e Baixo (Eixo Y)")]
    public float ylimitmin = -4.2f;
    public float ylimitemax = 4.2f;

    private float posicaoX_Final;

    [Header("Pontos de Saída do Tiro")]
    [Tooltip("Ponto de tiro na frente (Bico)")]
    public Transform pontoDeDisparo;

    [Header("Configurações de Tiro")]
    public GameObject ovoPrefab;
    public float intervaloTiro = 0.2f;
    private float cronometroTiro;

    [Header("Tiro Duplo")]
    [Range(5f, 80f)]
    public float anguloSegundoOvo = 20f;

    [Header("Munição e Interface")]
    public int ovosRestantes = 120;
    public TextMeshProUGUI textoHUD;
    public int ovosportiro = 2;

    private Animator meuAnimator;
    private SpriteRenderer sr;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        
         ovosRestantes = ovosRestantes;

        intervaloTiro = 0.18f;
        velocidadeMovimento = 8.5f;

        Debug.Log("🐔 Cena usando a galinha que já está na cena.");
        Debug.Log("🥚 Ovos iniciais: " + ovosRestantes);

        AjustarPosicaoInicialX();
        AtualizarInterface();
        AtualizarHealthBar();
    }

    void Update()
    {
        MoverGalinha();
        ControlarTiro();
    }

    void AjustarPosicaoInicialX()
    {
        if (usarPosicaoXManual)
        {
            posicaoX_Final = posicaoX_Manual;
        }
        else
        {
            Camera cam = Camera.main;

            if (cam != null)
            {
                float alturaCam = cam.orthographicSize;
                float larguraCam = alturaCam * cam.aspect;

                float metadeLarguraSprite =
                    (sr != null && sr.sprite != null)
                    ? sr.bounds.extents.x
                    : 0.5f;

                posicaoX_Final =
                    (cam.transform.position.x - larguraCam)
                    + metadeLarguraSprite
                    + 0.3f;
            }
            else
            {
                posicaoX_Final = transform.position.x;
            }
        }

        transform.position = new Vector3(
            posicaoX_Final,
            transform.position.y,
            transform.position.z
        );
    }

    void MoverGalinha()
    {
        float inputVertical = Input.GetAxis("Vertical");

        float novaPosicaoY =
            transform.position.y
            + (inputVertical * velocidadeMovimento * Time.deltaTime);

        float ytravado = Mathf.Clamp(
            novaPosicaoY,
            ylimitmin,
            ylimitemax
        );

        transform.position = new Vector3(
            posicaoX_Final,
            ytravado,
            transform.position.z
        );
    }

    void ControlarTiro()
    {
        cronometroTiro += Time.deltaTime;

        if (
            Input.GetKeyDown(KeyCode.Space)
            && cronometroTiro >= intervaloTiro
            && ovosRestantes >= ovosportiro
        )
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if (pontoDeDisparo == null || ovoPrefab == null)
        {
            Debug.LogError("⚠️ 'ovoPrefab' ou 'pontoDeDisparo' não foram configurados!");
            return;
        }

        switch (ovosportiro)
        {
            case 1:
                Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));
                break;

            case 2:
                Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));
                DispararDiagonal(anguloSegundoOvo);
                break;

            case 3:
                Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));
                DispararDiagonal(anguloSegundoOvo);
                DispararDiagonal(-anguloSegundoOvo);
                break;
        }

        ovosRestantes -= ovosportiro;
        if (ovosRestantes < 0) ovosRestantes = 0;

        cronometroTiro = 0f;
        AtualizarInterface();
    }

    void DispararDiagonal(float anguloBase)
    {
        float variacao = Random.Range(-10f, 10f);
        float anguloFinal = anguloBase + variacao;
        Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, anguloFinal));
    }

    void AtualizarInterface()
    {
        if (textoHUD != null)
        {
            textoHUD.text = "Ovos: " + ovosRestantes;
        }
    }
    public void AdicionarOvos(int quantidade)
    {
        ovosRestantes += quantidade;
        AtualizarInterface();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            life = 0;
            Morrer();
        }

        AtualizarHealthBar();
    }

    void Morrer()
    {
        Debug.Log("A galinha morreu!");

        gameObject.SetActive(false);

        SceneManager.LoadScene("GameOver");
    }

    void AtualizarHealthBar()
    {
        if (healthBarImage != null)
        {
            if (_lifemax <= 0)
            {
                _lifemax = 10;
            }

            healthBarImage.fillAmount =
                (float)life / _lifemax;
        }
    }
}
