using System.Collections;
using TMPro;
using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    public int preco = 95;
    public int preco2 = 95;
    public int idSkin = 1;
    public int idSkin2 = 4;
    public TMP_Text textoDinhero;
    public TMP_Text textoDinhero2;
    public float tempoAviso = 1.5f;

    void Start()
    {
        if (textoDinhero != null) textoDinhero.gameObject.SetActive(false);
        if (textoDinhero2 != null) textoDinhero2.gameObject.SetActive(false);
    }

    public void Comprar()
    {
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();
            if (galinha != null)
                galinha.EquiparSkin(idSkin);
            textoDinhero2.gameObject.SetActive(true);
            
        }
        else
        {
            StartCoroutine(MostrarAviso());
        }
    }

    public void ComprarItem1()
    {
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            GalinhaController galinhaController = FindFirstObjectByType<GalinhaController>();
            if (galinhaController != null)
            {
                galinhaController.velocidadeMovimento += 1f;
            }
        }
        else
        {
            StartCoroutine(MostrarAviso());
        }
    }

    IEnumerator MostrarAviso()
    {
        if (textoDinhero == null) yield break;

        textoDinhero.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoAviso);
        textoDinhero.gameObject.SetActive(false);
    }
    public void Comprarfestivo()
    {
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();
            if (galinha != null)
                galinha.EquiparSkin(idSkin2);
            textoDinhero2.gameObject.SetActive(true);

        }
        else
        {
            StartCoroutine(MostrarAviso());
        }
    }
}