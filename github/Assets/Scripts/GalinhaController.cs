using UnityEngine;
using TMPro; // Necessário para controlar o texto da UI

public class GalinhaController : MonoBehaviour
{
    public float ylimitemax = 4f; // Limite superior e inferior para a movimentação da galinha
    public float ylimitemin = -4f;  // Limite inferior para a movimentação da galinha
    [Header("Movimentação")]
    public float velocidadeMovimento = 8f;

    [Header("Sistema de Tiro")]
    public GameObject ovoPrefab;      // Arraste seu Prefab do Ovo aqui
    public Transform pontoDeDisparo;  // Arraste o objeto vazio 'PontoDeDisparo' aqui
    public float intervaloTiro = 0.2f;
    private float cronometroTiro;

    [Header("Munição e Interface")]
    public int ovosRestantes = 50;    // Quantidade inicial de ovos
    public TextMeshProUGUI textoHUD;  // Arraste o objeto de Texto (UI) aqui

    void Start()
    {
        // Garante que o texto comece com o valor correto
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
        transform.position += new Vector3(0, inputVertical, 0) * velocidadeMovimento * Time.deltaTime;

        // 2. Depois trava (com os valores que você ajustou no Inspector)
        float ytravado = Mathf.Clamp(transform.position.y, ylimitemin, ylimitemax);
        transform.position = new Vector3(transform.position.x, ytravado, transform.position.z);
        // Cria o vetor de movimento apenas no eixo Y
        Vector3 movimento = new Vector3(4, inputVertical, -4);

        // Aplica o movimento suavemente
        transform.position += movimento * velocidadeMovimento * Time.deltaTime;

       
    }

    void ControlarTiro()
    {
        // Aumenta o cronômetro a cada frame
        cronometroTiro += Time.deltaTime;

        // Se segurar Espaço, tiver passado o tempo do intervalo e tiver ovos...
        if (Input.GetKey(KeyCode.Space) && cronometroTiro >= intervaloTiro && ovosRestantes > 0)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        // Cria o ovo
        Instantiate(ovoPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);

        // Diminui a munição
        ovosRestantes--;

        // Reseta o cronômetro para o próximo tiro
        cronometroTiro = 0f;

        // Atualiza o texto na tela
        AtualizarInterface();
    }

    void AtualizarInterface()
    {
        if (textoHUD != null)
        {
            textoHUD.text = "Ovos: " + ovosRestantes.ToString();
        }
    }
}