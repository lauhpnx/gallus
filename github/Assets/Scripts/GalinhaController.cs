using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("Munição e Interface")]
    public int ovosRestantes = 30;
    public TextMeshProUGUI textoHUD;

    private Animator meuAnimator;
    private SpriteRenderer sr;
    private int skinEquipada = 0;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        AjustarPosicaoInicialX();
        AtualizarInterface();
        AtualizarHealthBar();
    }

    void Update()
    {
        MoverGalinha();
        ControlarTiro();
    }

    void ConfigurarStatusGalinha()
    {
        if (skinEquipada == 2)
        {
         
            ovosRestantes = 90;
            intervaloTiro = 0.15f;
            velocidadeMovimento = 9f;
        }
        else if (skinEquipada == 1)
        {
         
            ovosRestantes = 60;
            intervaloTiro = 0.18f;
            velocidadeMovimento = 8.5f;
        }
        else
        {
            
            ovosRestantes = 40;
            intervaloTiro = 0.25f;
            velocidadeMovimento = 8f;
        }
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

        transform.position = new Vector3(posicaoX_Final, transform.position.y, transform.position.z);
    }

    void MoverGalinha()
    {
        float inputVertical = Input.GetAxis("Vertical");

        float novaPosicaoY = transform.position.y + (inputVertical * velocidadeMovimento * Time.deltaTime);
        float ytravado = Mathf.Clamp(novaPosicaoY, ylimitmin, ylimitemax);

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

       
        if (skinEquipada == 2)
        {
            
            Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));
            Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 25f));  // Diagonal Cima
           

            ovosRestantes -= 3;
        }
        else if (skinEquipada == 1)
        {
            // GALINHA ESPECIAL: 2 Tiros (1 Reto e 1 na Diagonal Cima)
            Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));     
            Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 35f));  

            ovosRestantes -= 2;
        }
        else
        {
            Instantiate(ovoPrefab, pontoDeDisparo.position, Quaternion.Euler(0, 0, 0));
            ovosRestantes--;
        }

        if (ovosRestantes < 0) ovosRestantes = 0;

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