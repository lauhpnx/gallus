using UnityEngine;
using TMPro;

public class GalinhaController : MonoBehaviour
{
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
}