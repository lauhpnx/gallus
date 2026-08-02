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
    public float ylimitmin = -4.5f;
    public float ylimitemax = 4.5f;

    [Header("Sistema de Tiro")]
    public GameObject ovoPrefab;
    public Transform pontoDeDisparo;
    public float intervaloTiro = 0.2f;
    private float cronometroTiro;

    [Header("Munição e Interface")]
    public int ovosRestantes = 30;
    public TextMeshProUGUI textoHUD;

    private Animator meuAnimator;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();

        if (meuAnimator == null)
        {
            Debug.LogError("Animator não encontrado!");
        }

        AtualizarInterface();
        AtualizarHealthBar();
    }

    void Update()
    {
        MoverGalinha();
        ControlarTiro();
    }

    void MoverGalinha()
    {
        float inputVertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(0, inputVertical, 0)
                              * velocidadeMovimento * Time.deltaTime;

        float ytravado = Mathf.Clamp(transform.position.y, ylimitmin, ylimitemax);

        transform.position = new Vector3(transform.position.x, ytravado, transform.position.z);
    }

    void ControlarTiro()
    {
        cronometroTiro += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) &&
            cronometroTiro >= intervaloTiro &&
            ovosRestantes > 0)
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

        // 1. Esconde a galinha da tela
        gameObject.SetActive(false);

        // 2. Carrega a cena de GameOver 
        // (Certifique-se de que a cena se chama "GameOver" ou mude o texto abaixo)
        SceneManager.LoadScene("GameOver");
    }

    void AtualizarHealthBar()
    {
        if (healthBarImage != null)
        {
            // Proteção para evitar o erro de divisão por zero caso fique zerado no Inspector
            if (_lifemax <= 0)
            {
                _lifemax = 10;
            }

            healthBarImage.fillAmount = (float)life / _lifemax;
        }
    }
}
