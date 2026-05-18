using UnityEngine;
using TMPro;

public class GalinhaController : MonoBehaviour
{
    [Header("Movimentação e Limites")]
    public float velocidadeMovimento = 8f;
    public float ylimitmin = -4.5f; // Valor padrão para não sumir
    public float ylimitemax = 4.5f;  // Valor padrão para não sumir

    [Header("Sistema de Tiro")]
    public GameObject ovoPrefab;
    public Transform pontoDeDisparo;
    public float intervaloTiro = 0.2f;
    private float cronometroTiro;

    [Header("Munição e Interface")]
    public int ovosRestantes = 30;
    public TextMeshProUGUI textoHUD;

    void Start()
    {
        AtualizarInterface();
    }

    void Update()
    {
        MoverGalinha();
        ControlarTiro();
    }

    void MoverGalinha()
    {
        // 1. Captura o movimento do jogador
        float inputVertical = Input.GetAxis("Vertical");

        // 2. Aplica o movimento na galinha
        transform.position += new Vector3(0, inputVertical, 0) * velocidadeMovimento * Time.deltaTime;

        // 3. A TRAVA: Calcula a posição segura (Clamp)
        // Isso garante que o valor de Y nunca saia do intervalo entre min e max
        float ytravado = Mathf.Clamp(transform.position.y, ylimitmin, ylimitemax);

        // 4. APLICAÇÃO: Força a galinha a usar o valor travado
        // Mantemos o X e o Z originais e injetamos o Y corrigido
        transform.position = new Vector3(transform.position.x, ytravado, transform.position.z);
    }

    void ControlarTiro()
    {
        cronometroTiro += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cronometroTiro >= intervaloTiro && ovosRestantes > 0)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        Instantiate(ovoPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);
        ovosRestantes--;
        cronometroTiro = 0f;
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