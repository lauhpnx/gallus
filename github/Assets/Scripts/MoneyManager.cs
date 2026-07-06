using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int dinheiro = 0;

    public TMP_Text textoDinheiro;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        AtualizarTexto();
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

    void AtualizarTexto()
    {
        textoDinheiro.text = "$ " + dinheiro;
    }
}