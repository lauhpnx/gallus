using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int dinheiro = 0;
    public TMP_Text textoDinheiro;

    private void Awake()
    {
        // 1. Evita duplicar o MoneyManager quando voltar para esta cena
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Impede de ser destruído ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Se já existir um MoneyManager vindo da cena anterior, destrói o novo
            return;
        }
    }

    void Start()
    {
        AtualizarTexto();
    }

    // 2. Procura o texto da nova cena caso o 'textoDinheiro' fique vazio ao trocar de fase
    void Update()
    {
        if (textoDinheiro == null)
        {
            // Procura um objeto com o componente TMP_Text na nova cena
            textoDinheiro = FindFirstObjectByType<TMP_Text>();
            if (textoDinheiro != null)
            {
                AtualizarTexto();
            }
        }
    }

    public void AdicionarDinheiro(int valor)
    {
        dinheiro += valor;
        AtualizarTexto();
    }

    public bool GastarDinheiro(int valor)
    {
        if (dinheiro >= valor)
        {
            dinheiro -= valor;
            AtualizarTexto();
            return true;
        }

        return false;
    }

    public void AtualizarTexto()
    {
        if (textoDinheiro != null)
        {
            textoDinheiro.text = "$ " + dinheiro;
        }
    }
}