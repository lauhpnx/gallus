using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GalinhaController : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int life;
    public int _lifemax;
    public float _speed = 5f;
    [Header("ui do player(Barra de Vida)")]
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
        // 🔥 ANIMAÇÃO CORRETA (TRIGGER)
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
            // Aqui você pode adicionar lógica para quando a galinha morrer, como reiniciar o jogo ou mostrar uma tela de game over.
            Debug.Log("A galinha morreu!");
        }
        AtualizarHealthBar();
    }
    void AtualizarHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = (float)life / _lifemax;
        }
    }
}