using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalinhaController : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int life = 10;
    public int _lifemax = 10;
    public float _speed = 5f;

    [Header("UI do Player (Barra de Vida)")]
    public Image healthBarImage;

    [Header("Movimentação e Limites")]
    public float velocidadeMovimento = 8f;

    [Header("Posicionamento no Eixo X (Horizontal)")]
    [Tooltip("Marque TRUE para usar a Posição X manual. Marque FALSE para calcular automático.")]
    public bool usarPosicaoXManual = true;

    [Tooltip("Posição X exata onde a galinha vai ficar na fase (ex: -7.0)")]
    public float posicaoX_Manual = -7f;

    [Header("Limites de Cima e Baixo (Eixo Y)")]
    public float ylimitmin = -4.2f; // Limite do chão
    public float ylimitemax = 4.2f;  // Limite do teto

    private float posicaoX_Final;

    [Header("Sistema de Tiro")]
    public GameObject ovoPrefab;
    public Transform pontoDeDisparo;
    public float intervaloTiro = 0.2f;
    private float cronometroTiro;

    [Header("Munição e Interface")]
    public int ovosRestantes = 30;
    public TextMeshProUGUI textoHUD;

    private Animator meuAnimator;
    private SpriteRenderer sr;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (meuAnimator == null)
        {
            Debug.LogError("Animator não encontrado!");
        }

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
                float metadeLarguraSprite = (sr != null && sr.sprite != null) ? sr.bounds.extents.x : 0.5f;

                posicaoX_Final = (cam.transform.position.x - larguraCam) + metadeLarguraSprite + 0.3f;
            }
            else
            {
                posicaoX_Final = transform.position.x;
            }
        }

        // Aplica a posição X no objeto
        transform.position = new Vector3(posicaoX_Final, transform.position.y, transform.position.z);
    }

    void MoverGalinha()
    {
        float inputVertical = Input.GetAxis("Vertical"); // W / S ou Setas Cima / Baixo

        // Move a galinha no eixo Y
        float novaPosicaoY = transform.position.y + (inputVertical * velocidadeMovimento * Time.deltaTime);

        // Trava o Y estritamente entre o mínimo (chão) e o máximo (teto)
        float ytravado = Mathf.Clamp(novaPosicaoY, ylimitmin, ylimitemax);

        // Mantém a posição X travada na borda certa e aplica o Y limitado
        transform.position = new Vector3(posicaoX_Final, ytravado, transform.position.z);
    }

    void ControlarTiro()
    {
        cronometroTiro += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cronometroTiro >= intervaloTiro && ovosRestantes > 0)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if (meuAnimator != null)
        {
            meuAnimator.SetTrigger("Atirar");
        }

        Instantiate(ovoPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);

        ovosRestantes--;
        cronometroTiro = 0f;

        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        if (textoHUD != null)
        {
            textoHUD.text = "Ovos: " + ovosRestantes;
        }
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
            if (_lifemax <= 0) _lifemax = 10;
            healthBarImage.fillAmount = (float)life / _lifemax;
        }
    }
}