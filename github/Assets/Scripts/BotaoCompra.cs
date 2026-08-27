using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    public int preco = 95;
    public int idSkin = 1;

    public void Comprar()
    {
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();
            if (galinha != null)
                galinha.EquiparSkin(idSkin);
        }
        else
        {
            Debug.Log("❌ Dinheiro insuficiente!");
        }
    }
}